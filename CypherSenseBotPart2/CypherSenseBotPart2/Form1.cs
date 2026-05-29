namespace CypherSenseBotPart2
{
    public partial class Form1 : Form
    {
        // creating an instance of the chatbot class to use its methods in the form.
        private ChatBot chatBot;
        private bool coversationStart=false;
        public Form1()
        {
            InitializeComponent();
        }

        // the form load event.
        private void Form1_Load(object sender, EventArgs e)
        {
            //the voice will greet the user first
            VoiceGreeting.PlayAudio("greetingAudio.wav");

            // displaying the ascii art
            AsciiIArt asciiArt= new AsciiIArt();
            string art = asciiArt.GetAsciiArt();
            richTextBox1.SelectionColor = Color.Yellow;
            richTextBox1.AppendText(art + "\n");
            richTextBox1.SelectionColor = Color.Black;

            // displaying the greeting message from the chatbot.
            chatBot = new ChatBot();

            richTextBox1.SelectionColor = Color.DarkCyan;
            richTextBox1.AppendText("CypherSenseBot: " + chatBot.GetGreeting() + "\n");
            richTextBox1.AppendText("---\n");
            richTextBox1.SelectionColor = Color.Black;
        }

        // the send button click event.
        private void sendButton_Click(object sender, EventArgs e)
        {
            string userMessage = textBox1.Text.Trim();

            if (string.IsNullOrEmpty(userMessage))
            {
                richTextBox1.SelectionColor = Color.DarkRed;
                richTextBox1.AppendText("CypherSenseBot: Please enter a name to continue.\n");
                richTextBox1.AppendText("=================================================================================================================================================\n");
                richTextBox1.SelectionColor = Color.Black;
                return;
            }

           
            richTextBox1.SelectionColor = Color.Magenta;
            string currentUserName = chatBot.GetUserName();
            richTextBox1.AppendText($"{currentUserName}: {userMessage}\n");

            // Get bot response
            string botResponse = chatBot.ProcessMessage(userMessage);

            
            richTextBox1.SelectionColor = Color.DarkCyan;
            richTextBox1.AppendText($"CypherSenseBot: {botResponse}\n");

            
            richTextBox1.SelectionColor = Color.Black;
            richTextBox1.AppendText("---\n");

            textBox1.Clear();
            textBox1.Focus();

            richTextBox1.SelectionStart = richTextBox1.TextLength;
            richTextBox1.ScrollToCaret();
        }
       
        
    }
}
