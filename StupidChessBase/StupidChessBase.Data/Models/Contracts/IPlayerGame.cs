namespace StupidChessBase.Data.Models
{
    public interface IPlayerGame
    {
        IGame Game { get; set; }
        int GameId { get; set; }
        IPlayer Player { get; set; }
        int PlayerId { get; set; }
    }
}