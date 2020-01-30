public class GameBootstrap : StateMachine {
    public MenuController MenuController;
    public GameController GameController;
    public PauseController PauseController;
    public ResultController ResultController;
    public AudioService AudioService;
    public Conductor Conductor;
    public ScoreController ScoreController;
    
    public void Start() {
        this.ChangeState<InitializeGameState>();
    }
}
