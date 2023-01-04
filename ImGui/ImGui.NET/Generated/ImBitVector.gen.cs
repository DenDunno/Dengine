using System;

namespace ImGuiNET;

public unsafe partial struct ImBitVector {
	public ImVector Storage;
}
public unsafe partial struct ImBitVectorPtr {
	public ImBitVector* NativePtr { get; }
	public ImBitVectorPtr(ImBitVector* nativePtr) => NativePtr = nativePtr;
	public ImBitVectorPtr(IntPtr nativePtr) => NativePtr = (ImBitVector*)nativePtr;
	public static implicit operator ImBitVectorPtr(ImBitVector* nativePtr) => new(nativePtr);
	public static implicit operator ImBitVector*(ImBitVectorPtr wrappedPtr) => wrappedPtr.NativePtr;
	public static implicit operator ImBitVectorPtr(IntPtr nativePtr) => new(nativePtr);
	public ImVector<uint> Storage => new(NativePtr->Storage);
	public void Clear() => ImGuiNative.ImBitVector_Clear((ImBitVector*)(NativePtr));
	public void ClearBit(int n) => ImGuiNative.ImBitVector_ClearBit((ImBitVector*)(NativePtr), n);
	public void Create(int sz) => ImGuiNative.ImBitVector_Create((ImBitVector*)(NativePtr), sz);
	public void SetBit(int n) => ImGuiNative.ImBitVector_SetBit((ImBitVector*)(NativePtr), n);
	public bool TestBit(int n) {
		var ret = ImGuiNative.ImBitVector_TestBit((ImBitVector*)(NativePtr), n);
		return ret != 0;
	}
}
