using System;

namespace ImGuiNET;

public unsafe partial struct ImGuiWindowDockStyle {
	public fixed uint Colors[6];
}
public unsafe partial struct ImGuiWindowDockStylePtr {
	public ImGuiWindowDockStyle* NativePtr { get; }
	public ImGuiWindowDockStylePtr(ImGuiWindowDockStyle* nativePtr) => NativePtr = nativePtr;
	public ImGuiWindowDockStylePtr(IntPtr nativePtr) => NativePtr = (ImGuiWindowDockStyle*)nativePtr;
	public static implicit operator ImGuiWindowDockStylePtr(ImGuiWindowDockStyle* nativePtr) => new(nativePtr);
	public static implicit operator ImGuiWindowDockStyle*(ImGuiWindowDockStylePtr wrappedPtr) => wrappedPtr.NativePtr;
	public static implicit operator ImGuiWindowDockStylePtr(IntPtr nativePtr) => new(nativePtr);
	public RangeAccessor<uint> Colors => new(NativePtr->Colors, 6);
}
