using System.Runtime.CompilerServices;

// The translator's slot/mode predicates are pinned by tests. They decide
// whether an authored curve cluster reaches the emitted rows at all, and a
// wrong answer is silent: the profile translates, and the curve is simply
// absent. XBOXDS4ONE.Engine and XBOXDS4ONE.App already expose their internals to
// the test assembly for the same reason.
[assembly: InternalsVisibleTo("XBOXDS4ONE.Tests")]

// The library's own tests keep their process off Steam's servers
// (SteamHttp.OffLimitsForTest), which they can set only as a friend.
[assembly: InternalsVisibleTo("XBOXDS4ONE.SteamWorkshop.Tests")]
