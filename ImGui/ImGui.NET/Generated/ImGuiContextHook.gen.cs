using System;
using System.Runtime.CompilerServices;

namespace ImGuiNET;

public unsafe partial struct ImGuiContextHook {
	public uint HookId;
	public ImGuiContextHookType Type;
	public uint Owner;
	public IntPtr Callback;
	public void* UserData;
}
public unsafe partial struct ImGuiContextHookPtr {
	public ImGuiContextHook* NativePtr { get; }
	public ImGuiContextHookPtr(ImGuiContextHook* nativePtr) => NativePtr = nativePtr;
	public ImGuiContextHookPtr(IntPtr nativePtr) => NativePtr = (ImGuiContextHook*)nativePtr;
	public static implicit operator ImGuiContextHookPtr(ImGuiContextHook* nativePtr) => new(nativePtr);
	public static implicit operator ImGuiContextHook*(ImGuiContextHookPtr wrappedPtr) => wrappedPtr.NativePtr;
	public static implicit operator ImGuiContextHookPtr(IntPtr nativePtr) => new(nativePtr);
	public ref uint HookId => ref Unsafe.AsRef<uint>(&NativePtr->HookId);
	public ref ImGuiContextHookType Type => ref Unsafe.AsRef<ImGuiContextHookType>(&NativePtr->Type);
	public ref uint Owner => ref Unsafe.AsRef<uint>(&NativePtr->Owner);
	public ref IntPtr Callback => ref Unsafe.AsRef<IntPtr>(&NativePtr->Callback);
	public IntPtr UserData { get => (IntPtr)NativePtr->UserData; set => NativePtr->UserData = (void*)value; }
	public void Destroy() => ImGuiNative.ImGuiContextHook_destroy((ImGuiContextHook*)(NativePtr));
}
