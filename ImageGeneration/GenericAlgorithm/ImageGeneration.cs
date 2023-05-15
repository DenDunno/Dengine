using OpenTK.Mathematics;

public class ImageGeneration
{
    private readonly Texture2DData _targetTextureData;
    private readonly List<Genom> _population = new();
    private byte[] _targetData = Array.Empty<byte>();
    private byte[] _buffer = Array.Empty<byte>();
    private readonly List<Genom> _tournament = new(2);
    [EditorField] private readonly float _mutation = 0.001f;
    
    public ImageGeneration(Texture2DData targetTextureData)
    {
        _targetTextureData = targetTextureData;
    }

    public void GeneratePopulation(int populationSize)
    {
        _population.Clear();
        _targetData = _targetTextureData.RawData;
        Vector2i size = _targetTextureData.Size;
        _buffer = new byte[_targetTextureData.RawData.Length];
        
        for (int i = 0; i < populationSize; i++)
        {
            byte[] data = new byte[size.X * size.Y * 4];
            Random.Shared.NextBytes(data);
            _population.Add(CreateGenom(data));
        }
    }

    public Genom Evolve(int iterations = 1)
    {
        for (int i = 0; i < iterations; i++)
        {
            Genom parent1 = GetWinnerFromTournament();
            Genom parent2 = GetWinnerFromTournament();
        
            Genom offspring = Crossover(parent1, parent2);
            ApplyMutation(offspring);
        
            TryImprovePopulation(offspring);
        }
        
        return GetBestGenom();
    }

    private void TryImprovePopulation(Genom offspring)
    {
        for (int i = 0; i < _population.Count; ++i)
        {
            if (_population[i].Error >= offspring.Error)
            {
                _population[i] = new Genom((byte[])_buffer.Clone(), offspring.Error);
                break;
            }
        }
    }

    private Genom GetWinnerFromTournament(int size = 2)
    {
        _tournament.Clear();
        Genom winner = null!;
        float error = float.MaxValue;
        
        for (int i = 0; i < size; ++i)
        {
            _tournament.Add(_population.GetRandomElement());
        }

        foreach (Genom genom in _tournament)
        {
            if (genom.Error < error)
            {
                error = genom.Error;
                winner = genom;
            }
        }

        return winner;
    }

    private Genom Crossover(Genom parent1, Genom parent2)
    {
        int crossoverPoint = Random.Shared.Next(parent1.Data.Length);

        Array.Copy(parent1.Data, 0, _buffer, 0, crossoverPoint);
        Array.Copy(parent2.Data, crossoverPoint, _buffer, crossoverPoint, parent2.Data.Length - crossoverPoint);
        
        return CreateGenom(_buffer);
    }

    private void ApplyMutation(Genom offspring)
    {
        for (int i = 0; i < offspring.Data.Length; ++i)
        {
            if (Random.Shared.NextDouble() < _mutation)
            {
                offspring.Data[i] = (byte)Random.Shared.Next(0, 255);
            }
        }
    }

    private Genom GetBestGenom()
    {
        return _population.MaxBy(genom => genom.Error)!;
    }

    private Genom CreateGenom(byte[] data)
    {
        float fitness = MeanSquaredImageError.Evaluate(data, _targetData, _targetTextureData.Size);
        
        return new Genom(data, fitness);
    }
}