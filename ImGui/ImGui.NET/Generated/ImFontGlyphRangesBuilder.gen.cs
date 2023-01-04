using System;
using System.Text;

namespace ImGuiNET;

public unsafe partial struct ImFontGlyphRangesBuilder {
	public ImVector UsedChars;
}
public unsafe partial struct ImFontGlyphRangesBuilderPtr {
	public ImFontGlyphRangesBuilder* NativePtr { get; }
	public ImFontGlyphRangesBuilderPtr(ImFontGlyphRangesBuilder* nativePtr) => NativePtr = nativePtr;
	public ImFontGlyphRangesBuilderPtr(IntPtr nativePtr) => NativePtr = (ImFontGlyphRangesBuilder*)nativePtr;
	public static implicit operator ImFontGlyphRangesBuilderPtr(ImFontGlyphRangesBuilder* nativePtr) => new(nativePtr);
	public static implicit operator ImFontGlyphRangesBuilder*(ImFontGlyphRangesBuilderPtr wrappedPtr) => wrappedPtr.NativePtr;
	public static implicit operator ImFontGlyphRangesBuilderPtr(IntPtr nativePtr) => new(nativePtr);
	public ImVector<uint> UsedChars => new(NativePtr->UsedChars);
	public void AddChar(ushort c) => ImGuiNative.ImFontGlyphRangesBuilder_AddChar((ImFontGlyphRangesBuilder*)(NativePtr), c);
	public void AddRanges(IntPtr ranges) {
		var native_ranges = (ushort*)ranges.ToPointer();
		ImGuiNative.ImFontGlyphRangesBuilder_AddRanges((ImFontGlyphRangesBuilder*)(NativePtr), native_ranges);
	}
	public void AddText(string text) {
		byte* native_text;
		var text_byteCount = 0;
		if(text != null) {
			text_byteCount = Encoding.UTF8.GetByteCount(text);
			if(text_byteCount > Util.StackAllocationSizeLimit) {
				native_text = Util.Allocate(text_byteCount + 1);
			} else {
				var native_text_stackBytes = stackalloc byte[text_byteCount + 1];
				native_text = native_text_stackBytes;
			}
			var native_text_offset = Util.GetUtf8(text, native_text, text_byteCount);
			native_text[native_text_offset] = 0;
		} else { native_text = null; }
		byte* native_text_end = null;
		ImGuiNative.ImFontGlyphRangesBuilder_AddText((ImFontGlyphRangesBuilder*)(NativePtr), native_text, native_text_end);
		if(text_byteCount > Util.StackAllocationSizeLimit) {
			Util.Free(native_text);
		}
	}
	public void BuildRanges(out ImVector out_ranges) {
		fixed(ImVector* native_out_ranges = &out_ranges) {
			ImGuiNative.ImFontGlyphRangesBuilder_BuildRanges((ImFontGlyphRangesBuilder*)(NativePtr), native_out_ranges);
		}
	}
	public void Clear() => ImGuiNative.ImFontGlyphRangesBuilder_Clear((ImFontGlyphRangesBuilder*)(NativePtr));
	public void Destroy() => ImGuiNative.ImFontGlyphRangesBuilder_destroy((ImFontGlyphRangesBuilder*)(NativePtr));
	public bool GetBit(uint n) {
		var ret = ImGuiNative.ImFontGlyphRangesBuilder_GetBit((ImFontGlyphRangesBuilder*)(NativePtr), n);
		return ret != 0;
	}
	public void SetBit(uint n) => ImGuiNative.ImFontGlyphRangesBuilder_SetBit((ImFontGlyphRangesBuilder*)(NativePtr), n);
}
