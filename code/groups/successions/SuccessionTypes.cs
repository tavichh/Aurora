namespace aurora.groups.successions
{
	public enum SuccessionTypes
	{
		RandomCharacter , // a random character in the group is the leader.
		CharacterSeniority , // the next oldest member of the group is the leader.
		SamePlayer , // the next character of the player that was the leader, is the leader.
		PopularVote , // everyone votes and the one with the highest vote is the leader.
		WeightedVote , // everyone votes, just a chosen group votes more.
		CouncilVote , // a chosen group of people decide who will be the next leader
		SingleChoice, // group members rank their votes until a popular common vote is achieved
		None , // group disbands after death
	}
}
