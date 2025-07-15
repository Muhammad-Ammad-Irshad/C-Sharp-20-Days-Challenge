using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Day_18
{
    class User
    {
        public string Name { get; set; }
        public User(string name)
        {
            Name = name;
        }
    }
    class Message
    {
        public string Sender { get; set; }
        public string Content { get; set; }
        public DateTime Timestamp { get; set; }
        public Message(string sender, string content)
        {
            Sender = sender;
            Content = content;
            Timestamp = DateTime.Now;
        }
        public override string ToString()
        {
            return $"[{Timestamp:HH:mm}] {Sender}: {Content}";
        }
    }
    class ChatSession
    {
        private List<Message> chatHistory = new List<Message>();
        private string filePath = "Chatlog.txt";
        public ChatSession()
        {
            LoadHistory();
        }
        private void LoadHistory()
        {
            if(File.Exists(filePath))
            {
                string[] lines = File.ReadAllLines(filePath);
                Console.WriteLine("Chat History:");
                foreach (string line in lines)
                {
                    Console.WriteLine (line);
                }
            }
            else
            {
                File.Create(filePath).Close();
            }
        }
        public void StartChat(User user1, User user2)
        {
            Console.WriteLine("\nStart new chat (type 'exit' to quit)");
            bool chatting = true;
            bool isUser1Turn = true;

            while (chatting)
            {
                User currentUser = isUser1Turn ? user1 : user2;
                Console.WriteLine($"{currentUser.Name}: ");
                string input = Console.ReadLine();
                if(input.ToLower() == "exit")
                {
                    chatting = false;
                    continue;
                }
                Message msg = new Message(currentUser.Name, input);
                chatHistory.Add(msg);
                AppendMessageToFile(msg);

                isUser1Turn = !isUser1Turn;
            }
        }
        private void AppendMessageToFile(Message msg)
        {
            using (StreamWriter writer = File.AppendText(filePath))
            {
                writer.WriteLine(msg.ToString());
            }
        }
    }
    internal class Chat_log
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Chat");
            User user1 = new User("Ammad");
            User user2 = new User("Maddy");
            ChatSession session = new ChatSession();
            session.StartChat(user1, user2);
            Console.WriteLine("Chat ended.");
        }
    }
}
