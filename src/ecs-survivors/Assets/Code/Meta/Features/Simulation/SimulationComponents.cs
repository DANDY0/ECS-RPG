﻿using Code.Progress;
using Entitas;

namespace Code.Meta.Features.Simulation
{
    public class SimulationComponents
    {
        [Meta] public class Tick : IComponent { public float  Value; }
        [Meta] public class GoldGainBoost : ISavedComponent { public float  Value; }
        [Meta] public class Duration : ISavedComponent { public float  Value; }

    }
} 