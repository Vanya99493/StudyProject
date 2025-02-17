using System;

namespace AIIntegration
{
	[Serializable]
	public class Response
	{
		public Candidate[] candidates;
	}

	[Serializable]
	public class Candidate
	{
		public Content content;
	}

	[Serializable]
	public class Content
	{
		public string role; 
		public Part[] parts;
	}

	[Serializable]
	public class Part
	{
		public string text;
	}
}