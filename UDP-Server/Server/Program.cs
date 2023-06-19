using System.Net.Sockets;
using System.Net;
using System.Text;
using System.IO.Pipes;

namespace Server
{
	internal class Program
	{
		const int serverPort = 8888;
		static List<string> questions = new List<string>();
		static List<string> answers = new List<string>();
		static void Main(string[] args)
		{
			GetQuestions();
			GetAnswers();
			UdpClient server = new(serverPort);
			while (true)
			{
				IPEndPoint clientEndpoint = null;
				byte[] requestData = server.Receive(ref clientEndpoint);
				string requestMsg = Encoding.UTF8.GetString(requestData);

				Console.WriteLine($"client: {requestMsg}");
				SendResponse(server, clientEndpoint, GetAnswerForQuestion(requestMsg));
			}
		}

		private static void GetQuestions()
		{
			var lines = File.ReadAllLines("questions.txt");
			foreach (string line in lines)
				questions.Add(line);
		}

		private static void GetAnswers()
		{
			var lines = File.ReadAllLines("answers.txt");
			foreach (string line in lines)
				answers.Add(line);
		}

		private static string GetAnswerForQuestion(string question)
		{
			string answer = null;
			if (question == "client connected") 
				answer = "You connected!";
			else if (questions.Contains(question))
			{
				for (int i = 0; i < questions.Count; i++)
				{
					if (questions[i] == question)
						answer = answers[i];
				}
			}
			else
			{
				answer = "I can't response to this question(";
			}
			return answer;
		}

		public static void SendResponse(UdpClient server, IPEndPoint clientIP, string responseMsg)
		{
			Console.WriteLine($"server: {responseMsg}");
			byte[] responseData = Encoding.UTF8.GetBytes(responseMsg);
			server.Send(responseData, clientIP);
		}
	}
}