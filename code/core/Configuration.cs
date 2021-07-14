namespace aurora.core
{
	public static class Configuration
	{
		#region Chat Prefix
		public static readonly CommandPrefix PlayerCommand = new () { Prefix = '/' };
		public static readonly CommandPrefix AdminCommand = new () { Prefix = '!' , RestrictToAdmins = true };
		#endregion
	}
}
