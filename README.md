

### <p align="center">Build & Usage (.NET 7 required)</p>

 - git clone https://github.com/DenDunno/Dengine.git
 - cd Dengine
 - dotnet run --project DEMO_NAME/DEMO_NAME.csproj 

The editor has a similar UX to Unity. When play mode, use WASD + mouse for exploring.
 
 ### <p align="center">Avaliable demos</p>
  ### <p align="center">Particle system up to 1 million particles</p>
 **Command:** dotnet run --project ParticleSystemDemo/ParticleSystemDemo.csproj
 
 **Key features:**

 - Hold left mouse button to emit particles 
 - GPU instancing for rendering
 - Compute shader for update cycle
 - Zero CPU allocation. Particle data stores at SSBO (shader storage buffer object).
 - Usage of pool
 - Main bottleneck is emitting: accesing of SSBO from CPU side.

```c#
public unsafe void Emit(Vector3 position, int particlesCount = 1)
{ 
    _shaderStorageBuffer.Bind();
    Particle* particles = _shaderStorageBuffer.MapBuffer(BufferAccess.WriteOnly);
    
    for (int i = 0; i < particlesCount; ++i)
    {
        ResetParticle(particles, position);
        MovePoolIndex();
    }
    
    _shaderStorageBuffer.UnMapBuffer();
}
```
<p align="center">
<img src="https://dunnospace.com/images/particleSystem/particleSystem.gif?raw=true"/>
</p>



   ### <p align="center">GPU instancing</p>
 **Command:** dotnet run --project GPUInstancingDemo/GPUInstancingDemo.csproj
 
 **Key features:**
 
 - Compute shader for asteroids update
 - Perling noise shader for sun 
- Simple lighting shader for asteroids
 - Custom OBJ parser (Obj must be triangulated)
 - Rotating space skybox

  <p align="center">
<img src="https://dunnospace.com/images/gpuInstancing/gpuInstancing.gif?raw=true"/>
</p>

