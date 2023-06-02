### <p align="center">Build & Usage (.NET 7 required)</p>

 - git clone https://github.com/DenDunno/Dengine.git
 - cd REPO_NAME
 - dotnet run --project DEMO_NAME/DEMO_NAME.csproj 

The editor has a similar UX to Unity. When play mode, use WASD + mouse for exploring.
 
If you get "System.DllNotFoundException: Unable to load DLL 'cimgui' or one of its dependencies", load Visual C++ Redistributable from MS VS from https://learn.microsoft.com/en-US/cpp/windows/latest-supported-vc-redist?view=msvc-170

 ### <p align="center">Avaliable demos</p>
 

 - [Particle system](#Particle-system)
 - [GPU instancing](#GPU-instancing)
 - [LOD Group](#LOD-Group)

  ### <p align="center">Particle system</p>
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

### <p align="center">LOD Group</p>
 **Command:** dotnet run --project LODGroupDemo/LODGroupDemo.csproj
 
 **Key features:**
 
 - The selection of LOD  is determined by recalculating the distance between an object and the camera during runtime.

```c#
public void Bind()
{
    _current = GetLODMesh();
    _current.Bind();    
}

private MeshBinding GetLODMesh()
{
    float distance = Vector3.Distance(_camera.Transform.Position, _transform.Position);
    MeshBinding result = _lodMeshes[0].Mesh;

    for (int i = 0; i < _lodMeshes.Length - 1; ++i)
    {
        if (distance > _lodMeshes[i].Distance)
        {
            result = _lodMeshes[i + 1].Mesh;
        }
    }

    return result;
}
```
  <p align="center">
<img src="https://dunnospace.com/images/lodGroup/lodGroup.gif?raw=true"/>
</p>

