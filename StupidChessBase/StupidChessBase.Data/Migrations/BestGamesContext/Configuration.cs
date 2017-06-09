namespace StupidChessBase.Data.Migrations.BestGamesContext
{
    using Models.PosgtreModels;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<StupidChessBase.Data.Contexts.BestGamesContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            AutomaticMigrationDataLossAllowed = false;
            MigrationsDirectory = @"Migrations\BestGamesContext";
        }

        protected override void Seed(StupidChessBase.Data.Contexts.BestGamesContext context)
        {
            context.BestGames.Add(new BestGame() { PgnGame = @"1. e4 c5 2. Nf3 Nc6 3. d4 cxd4 4. Nxd4 g6 5. Nc3 Bg7 6. Be3 Nf6 7. Be2 O-O 8. O-O d6 9. f4 Qb6 10. N
a4 Qa5 11. Nc3 Qb6 12. Na4 Qb4 13. c3 Qa5 14. b4 Qc7 15. Bf3 Bd7 16. Rc1 Rad8 17. Nb2 Qb8 18. Qe2 e5
 19. Nxc6 Bxc6 20. fxe5 dxe5 21. Bc5 Rfe8 22. b5 b6 23. Bf2 Bb7 24. Nc4 Qc7 25. a4 Nd7 26. Kh1 Nc5 2
7. Bxc5 Qxc5 28. Rcd1 a6 29. Ne3 axb5 30. axb5 Qxc3 31. Nc4 Rd4 32. Nxb6 Qc5 33. Rxd4 exd4 34. Nc4 f
5 35. e5 Bxf3 36. Rxf3 Qxb5 37. e6 Qb1+ 38. Rf1 Qe4 39. Qd2 Qxe6 40. Nb2 Qe2 41. Qxe2 Rxe2 42. Nd3 R
d2 43. Ne1 Rd1 44. Kg1 Bh6 45. g3 Kg7 46. Nf3 Rxf1+ 47. Kxf1 d3 48. Ne5 d2 49. Ke2 Kf6 50. Nd3 Be3 5
1. h3 h5 52. Nb2 Bh6 53. Kf3 Ke5 54. Nd1 Kd4 55. Ke2 Bg5 56. Nf2 Kc3 57. g4 hxg4 58. hxg4 Kc2 59. gx
f5 gxf5 60. Nd1 f4 61. Nf2 Bh4 62. Nd1 Bg3 0-1" });

            context.SaveChanges();
        }
    }
}
