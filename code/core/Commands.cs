using System.Collections.Generic;
namespace aurora.core
{
	public struct Command
	{
		/// <summary>
		/// The name of the chat command that should appear in game. This is not the actual command that is entered, but serves as a aid for the player identifying specific commands.
		/// </summary>
		public string Name;
		/// <summary>
		/// A brief description of what the command does.
		/// </summary>
		public string Description;
		/// <summary>
		/// The actual commands that the player needs to enter for the command to be executed.
		/// </summary>
		public string[] Keys;
		/// <summary>
		/// A prefix character to differentiate commands (if desired). Should initialize to a default if not used.
		/// </summary>
		public char Prefix;
		/// <summary>
		/// The parameters for the command. Takes a variable name that is used during parsing and also the placeholder in the sentence.
		/// </summary>
		public Dictionary < string , int > Parameters;
	}
}
