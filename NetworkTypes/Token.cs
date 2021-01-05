using System;

namespace NetworkTypes
{
	[Serializable]
	public class Token
	{
		public Token(Member Member, string AuthToken)
		{
			this.Member = Member;
			this.AuthToken = AuthToken;
		}

		public Token Copy()
		{
			return new Token(new Member(this.Member.UserID, this.Member.Username, this.Member.Avatar), this.AuthToken);
		}

		public void Dispose()
		{
			if (this.Member != null && this.Member.Avatar != null)
			{
				this.Member.Avatar.Dispose();
			}
		}

		public Member Member;

		public string AuthToken;
	}
}
