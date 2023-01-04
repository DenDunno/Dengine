﻿using System.Numerics;
using System.Text;

namespace ImGuiNET;

public unsafe partial struct ImDrawListPtr {
	public void AddText(Vector2 pos, uint col, string text_begin) {
		var text_begin_bytecount = Encoding.UTF8.GetByteCount(text_begin);
		var native_text_begin = stackalloc byte[text_begin_bytecount + 1];
		fixed(char* text_begin_ptr = text_begin) {
			var native_text_begin_offset = Encoding.UTF8.GetBytes(text_begin_ptr, text_begin.Length, native_text_begin, text_begin_bytecount);
			native_text_begin[native_text_begin_offset] = 0;
		}
		byte* native_text_end = null;
		ImGuiNative.ImDrawList_AddText_Vec2(NativePtr, pos, col, native_text_begin, native_text_end);
	}

	public void AddText(ImFontPtr font, float font_size, Vector2 pos, uint col, string text_begin) {
		var native_font = font.NativePtr;
		var text_begin_bytecount = Encoding.UTF8.GetByteCount(text_begin);
		var native_text_begin = stackalloc byte[text_begin_bytecount + 1];
		fixed(char* text_begin_ptr = text_begin) {
			var native_text_begin_offset = Encoding.UTF8.GetBytes(text_begin_ptr, text_begin.Length, native_text_begin, text_begin_bytecount);
			native_text_begin[native_text_begin_offset] = 0;
		}
		byte* native_text_end = null;
		var wrap_width = 0.0f;
		Vector4* cpu_fine_clip_rect = null;
		ImGuiNative.ImDrawList_AddText_FontPtr(NativePtr, native_font, font_size, pos, col, native_text_begin, native_text_end, wrap_width, cpu_fine_clip_rect);
	}
}
