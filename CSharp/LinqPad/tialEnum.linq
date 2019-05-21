<Query Kind="Program" />

void Main()
{

Enum.GetValues(typeof(UserStatus)).Cast<UserStatus>().ToArray().Dump();
UserStatus a=UserStatus.NotFill;
var b=(int) a;
b.Dump();
}

	  public enum UserStatus
    {
        NotFill,
        Writing,
        Finish,
        _1stFail,
        _2ndFail,
        FinalCheckFail,
        _1stPass,
        _2ndPass,
        FinalCheckPass
    }

// Define other methods and classes here
