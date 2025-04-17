using System;
using System.Drawing;
using System.Windows.Forms;
using Client.Clients;
using OpenAI.Chat;

namespace GUI
{
    public partial class ChatForm : Form
    {
        private LLMClient _llmClient;
        private McpClient _mcpClient;

        public ChatForm()
        {
            InitializeComponent();
        }

        private async void buttonSend_Click(object sender, EventArgs e)
        {
            if (_llmClient == null)
                return;

            string text = textBoxText.Text;
            if (string.IsNullOrEmpty(text))
                return;

            try
            {
                textBoxText.Enabled = false;
                btnSend.Enabled = false;
                btnReset.Enabled = false;
                btnApply.Enabled = false;

                await _llmClient.SendMessage(text);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error sending message: {ex.Message}");
            }
            finally
            {
                textBoxText.Text = "";
                textBoxText.Enabled = true;
                btnSend.Enabled = true;
                btnApply.Enabled = true;
                btnReset.Enabled = true;
                textBoxText.Focus();
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            _llmClient.ClearHistoric();
            chatBox.Text = "";
            textBoxText.Text = "";
        }

        private async void btnApply_Click(object sender, EventArgs e)
        {
            _llmClient = null;
            _mcpClient = null;
            btnReset.Enabled = false;
            btnSend.Enabled = false;
            textBoxText.Enabled = false;
            textBoxText.Text = "";
            chatBox.Text = "";

            try
            {
                _llmClient = new LLMClient(textBoxEndpoint.Text, textBoxKey.Text, textBoxDeploymentName.Text);

                _llmClient.RegisterMessageCallback(message =>
                {
                    Invoke(() =>
                    {
                        string text = GetTextFromCollection(message.Content);

                        if (message is UserChatMessage)
                        {
                            AppendColoredText(chatBox, "[User]: " + text + "\n", Color.Green);
                        }
                        else if (message is AssistantChatMessage)
                        {
                            AppendColoredText(chatBox, "[Assistant]: " + text + "\n", Color.Blue);
                        }
                        else if (message is ToolChatMessage)
                        {
                            AppendColoredText(chatBox, "[Tool]: " + text + "\n", Color.Magenta);
                        }
                        else
                        {
                            AppendColoredText(chatBox, "[Other]: " + text + "\n", Color.Black);
                        }
                    });
                });

                _llmClient.RegisterToolCallback((tool, args) =>
                {
                    bool allowExecution = false;

                    Invoke(() =>
                    {
                        DialogResult result = MessageBox.Show(
                            $"The LLM wants to invoke the tool {tool}\nArguments are: {args}",
                            "Tool Execution Request",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question
                        );

                        allowExecution = (result == DialogResult.Yes);
                    });

                    return allowExecution;
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error in Azure OpenAI Setup: {ex.Message}");
                _llmClient = null;
                return;
            }

            if (!string.IsNullOrEmpty(textBoxCommand.Text) || !string.IsNullOrEmpty(textBoxArgs.Text))
            {
                try
                {
                    var args = textBoxArgs.Text.Split('\n');
                    _mcpClient = new McpClient(textBoxName.Text, textBoxCommand.Text, args);
                    await _mcpClient.Connect();

                    _llmClient.SetMcpClient(_mcpClient);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error in MCP Server connection: {ex.Message}");

                    _mcpClient = null;
                    _llmClient = null;

                    return;
                }
            }

            textBoxText.Enabled = true;
            btnSend.Enabled = true;
            btnReset.Enabled = true;
        }

        private void AppendColoredText(RichTextBox richTextBox, string text, Color color)
        {
            int start = richTextBox.TextLength;
            richTextBox.SelectionStart = start;
            richTextBox.SelectionLength = 0;

            richTextBox.SelectionColor = color;
            richTextBox.AppendText(text);
            richTextBox.SelectionColor = richTextBox.ForeColor;

            chatBox.ScrollToCaret();
        }

        private static string GetTextFromCollection(ChatMessageContent content)
        {
            var result = string.Empty;

            foreach (var part in content)
            {
                result += part.Text;
            }

            return result;
        }

        private void textBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (e.Shift)
                    return;
                
                e.SuppressKeyPress = true;
                btnSend.PerformClick();
            }
        }
    }
}
