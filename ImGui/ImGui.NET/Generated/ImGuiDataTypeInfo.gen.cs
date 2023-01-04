using System;
using System.Runtime.CompilerServices;

namespace ImGuiNET;

public unsafe partial struct ImGuiDataTypeInfo {
	public uint Size;
	public byte* Name;
	public byte* PrintFmt;
	public byte* ScanFmt;
}
public unsafe partial struct ImGuiDataTypeInfoPtr {
	public ImGuiDataTypeInfo* NativePtr { get; }
	public ImGuiDataTypeInfoPtr(ImGuiDataTypeInfo* nativePtr) => NativePtr = nativePtr;
	public ImGuiDataTypeInfoPtr(IntPtr nativePtr) => NativePtr = (ImGuiDataTypeInfo*)nativePtr;
	public static implicit operator ImGuiDataTypeInfoPtr(ImGuiDataTypeInfo* nativePtr) => new(nativePtr);
	public static implicit operator ImGuiDataTypeInfo*(ImGuiDataTypeInfoPtr wrappedPtr) => wrappedPtr.NativePtr;
	public static implicit operator ImGuiDataTypeInfoPtr(IntPtr nativePtr) => new(nativePtr);
	public ref uint Size => ref Unsafe.AsRef<uint>(&NativePtr->Size);
	public NullTerminatedString Name => new(NativePtr->Name);
	public IntPtr PrintFmt { get => (IntPtr)NativePtr->PrintFmt; set => NativePtr->PrintFmt = (byte*)value; }
	public IntPtr ScanFmt { get => (IntPtr)NativePtr->ScanFmt; set => NativePtr->ScanFmt = (byte*)value; }
}
