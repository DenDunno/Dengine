using System;
using System.Runtime.CompilerServices;

namespace ImGuiNET;

public unsafe partial struct ImGuiMenuColumns {
	public float Spacing;
	public float Width;
	public float NextWidth;
	public fixed float Pos[3];
	public fixed float NextWidths[3];
}
public unsafe partial struct ImGuiMenuColumnsPtr {
	public ImGuiMenuColumns* NativePtr { get; }
	public ImGuiMenuColumnsPtr(ImGuiMenuColumns* nativePtr) => NativePtr = nativePtr;
	public ImGuiMenuColumnsPtr(IntPtr nativePtr) => NativePtr = (ImGuiMenuColumns*)nativePtr;
	public static implicit operator ImGuiMenuColumnsPtr(ImGuiMenuColumns* nativePtr) => new(nativePtr);
	public static implicit operator ImGuiMenuColumns*(ImGuiMenuColumnsPtr wrappedPtr) => wrappedPtr.NativePtr;
	public static implicit operator ImGuiMenuColumnsPtr(IntPtr nativePtr) => new(nativePtr);
	public ref float Spacing => ref Unsafe.AsRef<float>(&NativePtr->Spacing);
	public ref float Width => ref Unsafe.AsRef<float>(&NativePtr->Width);
	public ref float NextWidth => ref Unsafe.AsRef<float>(&NativePtr->NextWidth);
	public RangeAccessor<float> Pos => new(NativePtr->Pos, 3);
	public RangeAccessor<float> NextWidths => new(NativePtr->NextWidths, 3);
	public float CalcExtraSpace(float avail_w) {
		var ret = ImGuiNative.ImGuiMenuColumns_CalcExtraSpace((ImGuiMenuColumns*)(NativePtr), avail_w);
		return ret;
	}
	public float DeclColumns(float w0, float w1, float w2) {
		var ret = ImGuiNative.ImGuiMenuColumns_DeclColumns((ImGuiMenuColumns*)(NativePtr), w0, w1, w2);
		return ret;
	}
	public void Destroy() => ImGuiNative.ImGuiMenuColumns_destroy((ImGuiMenuColumns*)(NativePtr));
	public void Update(int count, float spacing, bool clear) {
		var native_clear = clear ? (byte)1 : (byte)0;
		ImGuiNative.ImGuiMenuColumns_Update((ImGuiMenuColumns*)(NativePtr), count, spacing, native_clear);
	}
}
