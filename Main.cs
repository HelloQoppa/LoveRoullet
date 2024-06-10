using Godot;
using System;

public partial class Main : Node
{
    private Random _random = new Random();
    private Label _itemLabel; // Referência ao Label
    private Timer _spinTimer; // Referência ao Timer
    private AudioStreamPlayer2D _clickSoundPlayer; // Referência ao AudioStreamPlayer2D
    private AnimationPlayer _animationPlayer; // Referência ao AnimationPlayer

    private string[] _rouletteItems = new string[]
    {
        "dar uma mordida no pescoço do seu parceiro",
        "Fazer uma Massagem provocante",
        "Dar uma Tapa No Bumbum  do seu parceiro",
        "Susurrar no ouvidinho sacanagens",
        "Dar um Beijo de lingua",
        "Que usar a sua lingua, Seja Criativo!",
        "Tirar uma peça de roupa",
        "Fazer uma Dança sensual"
    };

    private string _selectedItem; // Armazenar o item selecionado

    public override void _Ready()
    {
        // Obter referência aos nós
        _itemLabel = GetNode<Label>("ItemLabel");
        _spinTimer = GetNode<Timer>("SpinTimer");
        _clickSoundPlayer = GetNode<AudioStreamPlayer2D>("ClickSoundPlayer");
        _animationPlayer = GetNode<AnimationPlayer>("RouletteAnimationPlayer");

        // Conectar o sinal "pressed" do botão ao método OnSpinButtonPressed
        Button spinButton = GetNode<Button>("Button");
        spinButton.Connect("pressed", new Callable(this, nameof(OnSpinButtonPressed)));

        // Conectar o sinal "timeout" do Timer ao método OnSpinTimerTimeout
        _spinTimer.Connect("timeout", new Callable(this, nameof(OnSpinTimerTimeout)));
    }

    private void OnSpinButtonPressed()
    {
        // Limpar o texto do Label
        _itemLabel.Text = "";

        // Tocar o som
        _clickSoundPlayer.Play();

        // Iniciar o temporizador de 5 segundos
        _spinTimer.Start();

        // Iniciar a animação de rotação
        _animationPlayer.Play("SpinAnimation");
    }

    private void OnSpinTimerTimeout()
    {
        // Parar a animação (opcional)
        _animationPlayer.Stop();

        // Sortear o item
        SpinRoulette();

        // Exibir o item sorteado no Label após 5 segundos
        _itemLabel.Text = "Você tera que: " + _selectedItem;
    }

    public void SpinRoulette()
    {
        int randomIndex = _random.Next(_rouletteItems.Length);
        _selectedItem = _rouletteItems[randomIndex];
    }
}
