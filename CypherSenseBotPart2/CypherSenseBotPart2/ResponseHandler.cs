using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace CypherSenseBotPart2
{
    public class ResponseHandler
    {
        // five private fields
        private Memory memory;
        private Sentiment sentiment;
        private delegate string Chat(string message);
        private Chat botReply;
        private Dictionary<string, List<string>> responses;
        private Random random;

        // the responsehandler constructor that recieves the memory.
        public ResponseHandler(Memory mem)
        {
            memory = mem;
            sentiment = new Sentiment();
            random = new Random();
            botReply = GenerateResponse;



            responses = new Dictionary<string, List<string>>()
            {
                {
                    "hello", new List<string>()
                    {
                        "Hello! How can I assist you with cybersecurity today?",
                        "Hi there! What cybersecurity topic would you like to learn about?",
                        "Greetings! I'm here to help you with any cybersecurity questions you may have."
                    }
                },
                {
                    "hi", new List<string>()
                    {
                        "Hi! How can I assist you with cybersecurity today?",
                        "Hello there! What cybersecurity topic would you like to learn about?",
                        "Greetings! I'm here to help you with any cybersecurity questions you may have."
                    }
                },
                {
                    "how are you", new List<string>()
                    {
                        "I'm doing well, thank you for asking! How can I assist you with cybersecurity today?",
                        "I'm here to help you with any cybersecurity questions you may have. What would you like to learn about?"
                    }
                },
                {
                    "who are you", new List<string>()
                    {
                        "I am CypherSense, your cybersecurity awareness chatbot. I'm here to help you learn about various cybersecurity topics and how to stay safe online.",
                        "I'm CypherSense, a chatbot designed to provide information and guidance on cybersecurity topics. How can I assist you today?"
                    }
                },
                {
                    "what is your purpose", new List<string>()
                    {
                        "My purpose is to educate and raise awareness about cybersecurity topics, helping you stay safe online.",
                        "I'm here to provide information and guidance on various cybersecurity topics, so you can make informed decisions and protect yourself online."
                    }
                },
                { "password", new List<string>()
                    {
                        "A strong password should be at least 12 characters long and include a mix of uppercase letters, lowercase letters, numbers, and special characters.",
                        "Avoid using common words or phrases in your passwords, as they can be easily guessed by attackers.",
                        "Consider using a passphrase, which is a sequence of words that is easy for you to remember but difficult for others to guess."
                    }
                },
                { "phishing", new List<string>()
                    {
                        "Phishing is a type of cyber attack where attackers impersonate legitimate organizations to trick individuals into providing sensitive information.",
                        "Be cautious of unsolicited emails or messages that ask for personal information or contain suspicious links.",
                        "Always verify the sender's email address and look for signs of phishing, such as poor grammar or urgent requests."
                    }
                },
                { "scam", new List<string>()
                    {
                        "Never share personal info with unknown people online.",
                        "Be skeptical of offers that seem too good to be true.",
                        "Verify the identity of anyone asking for sensitive information.",
                        "Report suspicious activity to the relevant authorities."
                    }
                },
                { "privacy", new List<string>()
                    {
                        "Protect your privacy  Only share information on trusted platforms.",
                        "Use strong, unique passwords for each of your accounts.",
                        "Regularly review your privacy settings on social media."
                    }
                },
                { "malware", new List<string>()
                    {
                        "Keep your software and operating system up to date to protect against malware.",
                        "Use reputable antivirus software and perform regular scans.",
                        "Be cautious when downloading files or clicking on links from unknown sources."
                    }
                },
                { "DDoS", new List<string>()
                    {
                        "DDoS attacks can overwhelm your network or website with traffic.",
                        "Implement rate limiting to prevent abuse.",
                        "Use a content delivery network (CDN) to distribute traffic."
                    }
                },
                 { "DoS", new List<string>()
                    {
                        "DoS attacks can overwhelm your network or website with traffic.",
                        "Implement rate limiting to prevent abuse.",
                        "Use a content delivery network (CDN) to distribute traffic."
                    }
                },
                  { "espionage", new List<string>()
                    {
                        "Espionage involves the secret gathering of information, often for political or military purposes.",
                        "Be cautious of unusual behavior or communications from individuals who may have access to sensitive information.",
                        "Report any suspicious activities to the appropriate authorities."
                    }
                },
                   { "virus", new List<string>()
                    {
                        "Virus attacks can spread malicious code to your system.",
                        "Use reputable antivirus software and perform regular scans.",
                        "Avoid downloading files or clicking on links from unknown sources."
                    }
                },
                    { "intellectual property", new List<string>()
                    {
                        "Intellectual property theft involves the unauthorized use or distribution of copyrighted material.",
                        "Respect the rights of content creators and only use materials that you have permission to use.",
                        "Report any instances of intellectual property theft to the appropriate authorities."
                    }
                },
                     { "social engineering", new List<string>()
                    {
                        "Social engineering attacks manipulate people into divulging confidential information.",
                        "Be cautious of unsolicited communications and verify the identity of anyone requesting sensitive information.",
                        "Report any suspicious activities to the appropriate authorities."
                    }
                },
                      { "internet threats", new List<string>()
                    {
                        "Internet threats can include various malicious activities targeting your online presence.",
                        "Use reputable security software and keep it updated.",
                        "Be cautious when sharing personal information online."
                    }
                },
            };
        }

        // a method that generates a response based on the user input and the topics in the responses dictionary.
        public string GenerateResponse(string userInput)
        {
            string lowerInput = userInput.ToLower();
            string userName = memory.getUserName();

            // Detect sentiment from user input
            string detectedSentiment = sentiment.DetectSentiment(userInput);

            var sortedTopics = responses.Keys.OrderByDescending(k => k.Length);
            // check if the user input contains any of the topics in the responses dictionary
            foreach (var topic in sortedTopics)
            {
                if (lowerInput.Contains(topic))
                {
                    memory.storeTopics(topic);
                    List<string> topicResponses = responses[topic];

                    int randomIndex = random.Next(topicResponses.Count);
                    string baseResponse = topicResponses[randomIndex];

                    sentiment.SetUserInput(userInput);
                    string sentimentPrefix = sentiment.GetSentimentPrefix(detectedSentiment, topic);
                    string personalizedResponse = sentimentPrefix + "\n" + baseResponse;

                    // Get favorite topic from memory 
                    string favoriteTopic = memory.getFavoriteTopic();
                    if (!string.IsNullOrEmpty(favoriteTopic) && favoriteTopic == topic)
                    {
                        int topicCount = memory.GetTopicsTracker(topic);
                        if (topicCount >= 3)
                        {
                            personalizedResponse += $"\n\nI see this is your favorite topic, {userName}! You've asked about {topic} quite a bit!";
                        }
                    }
                    return personalizedResponse;
                }
            }
                return "I'm sorry, I don't have information on that topic. Please ask about another cybersecurity topic.";
            }

        // A public method that uses the delegate to process messages
        public string ProcessMessage(string userInput)
        {
            return botReply(userInput);
        }
    }
}


