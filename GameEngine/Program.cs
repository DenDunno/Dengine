﻿
WindowFactory windowFactory = new();
Window window = windowFactory.Create();

WorldFactory worldFactory = new Demo2D(window.Input);
World world = worldFactory.Create();

Engine engine = new(window, world, new UI(window, world));
engine.Initialize();
engine.Run();