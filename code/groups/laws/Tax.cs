namespace aurora.groups.laws
{
	public enum Tax
	{
		/// <summary>
		/// Tax the player whenever they buy anything.
		/// </summary>
		UserBuys ,
		/// <summary>
		/// Tax the player whenever they sell anything.
		/// </summary>
		UserSells ,
		RoundBegins ,
		DepositMoney ,
		WithdrawMoney ,
		UserBuysFromGroup ,
		UserSellsToGroup ,
		UserBecomesIdle ,
		UserBuysProperty ,
		UserSellsProperty ,
	}
}
