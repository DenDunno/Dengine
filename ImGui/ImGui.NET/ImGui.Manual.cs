using System;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Text;

namespace ImGuiNET;

public static unsafe partial class ImGui {
	public static bool InputText(
		string label,
		byte[] buf,
		uint buf_size) => InputText(label, buf, buf_size, 0, null, IntPtr.Zero);

	public static bool InputText(
		string label,
		byte[] buf,
		uint buf_size,
		ImGuiInputTextFlags flags) => InputText(label, buf, buf_size, flags, null, IntPtr.Zero);

	public static bool InputText(
		string label,
		byte[] buf,
		uint buf_size,
		ImGuiInputTextFlags flags,
		ImGuiInputTextCallback callback) => InputText(label, buf, buf_size, flags, callback, IntPtr.Zero);

	public static bool InputText(
		string label,
		byte[] buf,
		uint buf_size,
		ImGuiInputTextFlags flags,
		ImGuiInputTextCallback callback,
		IntPtr user_data) {
		var utf8_label_byte_count = Encoding.UTF8.GetByteCount(label);
		byte* utf8_label_bytes;
		if(utf8_label_byte_count > Util.StackAllocationSizeLimit) {
			utf8_label_bytes = Util.Allocate(utf8_label_byte_count + 1);
		} else {
			var stack_ptr = stackalloc byte[utf8_label_byte_count + 1];
			utf8_label_bytes = stack_ptr;
		}
		Util.GetUtf8(label, utf8_label_bytes, utf8_label_byte_count);

		bool ret;
		fixed(byte* buf_ptr = buf) {
			ret = ImGuiNative.igInputText(utf8_label_bytes, buf_ptr, buf_size, flags, callback, user_data.ToPointer()) != 0;
		}

		if(utf8_label_byte_count > Util.StackAllocationSizeLimit) {
			Util.Free(utf8_label_bytes);
		}

		return ret;
	}

	public static bool InputText(
		string label,
		ref string input,
		uint max_length) => InputText(label, ref input, max_length, 0, null, IntPtr.Zero);

	public static bool InputText(
		string label,
		ref string input,
		uint max_length,
		ImGuiInputTextFlags flags) => InputText(label, ref input, max_length, flags, null, IntPtr.Zero);

	public static bool InputText(
		string label,
		ref string input,
		uint max_length,
		ImGuiInputTextFlags flags,
		ImGuiInputTextCallback callback) => InputText(label, ref input, max_length, flags, callback, IntPtr.Zero);

	public static bool InputText(
		string label,
		ref string input,
		uint max_length,
		ImGuiInputTextFlags flags,
		ImGuiInputTextCallback callback,
		IntPtr user_data) {
		var utf8_label_byte_count = Encoding.UTF8.GetByteCount(label);
		byte* utf8_label_bytes;
		if(utf8_label_byte_count > Util.StackAllocationSizeLimit) {
			utf8_label_bytes = Util.Allocate(utf8_label_byte_count + 1);
		} else {
			var stack_ptr = stackalloc byte[utf8_label_byte_count + 1];
			utf8_label_bytes = stack_ptr;
		}
		Util.GetUtf8(label, utf8_label_bytes, utf8_label_byte_count);

		var utf8_input_byte_count = Encoding.UTF8.GetByteCount(input);
		var input_buf_size = Math.Max((int)max_length + 1, utf8_input_byte_count + 1);

		byte* utf8_input_bytes;
		byte* original_utf8_input_bytes;
		if(input_buf_size > Util.StackAllocationSizeLimit) {
			utf8_input_bytes = Util.Allocate(input_buf_size);
			original_utf8_input_bytes = Util.Allocate(input_buf_size);
		} else {
			var input_stack_bytes = stackalloc byte[input_buf_size];
			utf8_input_bytes = input_stack_bytes;
			var original_input_stack_bytes = stackalloc byte[input_buf_size];
			original_utf8_input_bytes = original_input_stack_bytes;
		}
		Util.GetUtf8(input, utf8_input_bytes, input_buf_size);
		var clear_bytes_count = (uint)(input_buf_size - utf8_input_byte_count);
		Unsafe.InitBlockUnaligned(utf8_input_bytes + utf8_input_byte_count, 0, clear_bytes_count);
		Unsafe.CopyBlock(original_utf8_input_bytes, utf8_input_bytes, (uint)input_buf_size);

		var result = ImGuiNative.igInputText(
			utf8_label_bytes,
			utf8_input_bytes,
			(uint)input_buf_size,
			flags,
			callback,
			user_data.ToPointer());
		if(!Util.AreStringsEqual(original_utf8_input_bytes, input_buf_size, utf8_input_bytes)) {
			input = Util.StringFromPtr(utf8_input_bytes);
		}

		if(utf8_label_byte_count > Util.StackAllocationSizeLimit) {
			Util.Free(utf8_label_bytes);
		}
		if(input_buf_size > Util.StackAllocationSizeLimit) {
			Util.Free(utf8_input_bytes);
			Util.Free(original_utf8_input_bytes);
		}

		return result != 0;
	}

	public static bool InputTextMultiline(
		string label,
		ref string input,
		uint max_length,
		Vector2 size) => InputTextMultiline(label, ref input, max_length, size, 0, null, IntPtr.Zero);

	public static bool InputTextMultiline(
		string label,
		ref string input,
		uint max_length,
		Vector2 size,
		ImGuiInputTextFlags flags) => InputTextMultiline(label, ref input, max_length, size, flags, null, IntPtr.Zero);

	public static bool InputTextMultiline(
		string label,
		ref string input,
		uint max_length,
		Vector2 size,
		ImGuiInputTextFlags flags,
		ImGuiInputTextCallback callback) => InputTextMultiline(label, ref input, max_length, size, flags, callback, IntPtr.Zero);

	public static bool InputTextMultiline(
		string label,
		ref string input,
		uint max_length,
		Vector2 size,
		ImGuiInputTextFlags flags,
		ImGuiInputTextCallback callback,
		IntPtr user_data) {
		var utf8_label_byte_count = Encoding.UTF8.GetByteCount(label);
		byte* utf8_label_bytes;
		if(utf8_label_byte_count > Util.StackAllocationSizeLimit) {
			utf8_label_bytes = Util.Allocate(utf8_label_byte_count + 1);
		} else {
			var stack_ptr = stackalloc byte[utf8_label_byte_count + 1];
			utf8_label_bytes = stack_ptr;
		}
		Util.GetUtf8(label, utf8_label_bytes, utf8_label_byte_count);

		var utf8_input_byte_count = Encoding.UTF8.GetByteCount(input);
		var input_buf_size = Math.Max((int)max_length + 1, utf8_input_byte_count + 1);

		byte* utf8_input_bytes;
		byte* original_utf8_input_bytes;
		if(input_buf_size > Util.StackAllocationSizeLimit) {
			utf8_input_bytes = Util.Allocate(input_buf_size);
			original_utf8_input_bytes = Util.Allocate(input_buf_size);
		} else {
			var input_stack_bytes = stackalloc byte[input_buf_size];
			utf8_input_bytes = input_stack_bytes;
			var original_input_stack_bytes = stackalloc byte[input_buf_size];
			original_utf8_input_bytes = original_input_stack_bytes;
		}
		Util.GetUtf8(input, utf8_input_bytes, input_buf_size);
		var clear_bytes_count = (uint)(input_buf_size - utf8_input_byte_count);
		Unsafe.InitBlockUnaligned(utf8_input_bytes + utf8_input_byte_count, 0, clear_bytes_count);
		Unsafe.CopyBlock(original_utf8_input_bytes, utf8_input_bytes, (uint)input_buf_size);

		var result = ImGuiNative.igInputTextMultiline(
			utf8_label_bytes,
			utf8_input_bytes,
			(uint)input_buf_size,
			size,
			flags,
			callback,
			user_data.ToPointer());
		if(!Util.AreStringsEqual(original_utf8_input_bytes, input_buf_size, utf8_input_bytes)) {
			input = Util.StringFromPtr(utf8_input_bytes);
		}

		if(utf8_label_byte_count > Util.StackAllocationSizeLimit) {
			Util.Free(utf8_label_bytes);
		}
		if(input_buf_size > Util.StackAllocationSizeLimit) {
			Util.Free(utf8_input_bytes);
			Util.Free(original_utf8_input_bytes);
		}

		return result != 0;
	}

	public static bool InputTextWithHint(
		string label,
		string hint,
		ref string input,
		uint max_length) => InputTextWithHint(label, hint, ref input, max_length, 0, null, IntPtr.Zero);

	public static bool InputTextWithHint(
		string label,
		string hint,
		ref string input,
		uint max_length,
		ImGuiInputTextFlags flags) => InputTextWithHint(label, hint, ref input, max_length, flags, null, IntPtr.Zero);

	public static bool InputTextWithHint(
		string label,
		string hint,
		ref string input,
		uint max_length,
		ImGuiInputTextFlags flags,
		ImGuiInputTextCallback callback) => InputTextWithHint(label, hint, ref input, max_length, flags, callback, IntPtr.Zero);

	public static bool InputTextWithHint(
		string label,
		string hint,
		ref string input,
		uint max_length,
		ImGuiInputTextFlags flags,
		ImGuiInputTextCallback callback,
		IntPtr user_data) {
		var utf8_label_byte_count = Encoding.UTF8.GetByteCount(label);
		byte* utf8_label_bytes;
		if(utf8_label_byte_count > Util.StackAllocationSizeLimit) {
			utf8_label_bytes = Util.Allocate(utf8_label_byte_count + 1);
		} else {
			var stack_ptr = stackalloc byte[utf8_label_byte_count + 1];
			utf8_label_bytes = stack_ptr;
		}
		Util.GetUtf8(label, utf8_label_bytes, utf8_label_byte_count);

		var utf8HintByteCount = Encoding.UTF8.GetByteCount(hint);
		byte* utf8HintBytes;
		if(utf8HintByteCount > Util.StackAllocationSizeLimit) {
			utf8HintBytes = Util.Allocate(utf8HintByteCount + 1);
		} else {
			var stack_ptr = stackalloc byte[utf8HintByteCount + 1];
			utf8HintBytes = stack_ptr;
		}
		Util.GetUtf8(hint, utf8HintBytes, utf8HintByteCount);

		var utf8_input_byte_count = Encoding.UTF8.GetByteCount(input);
		var input_buf_size = Math.Max((int)max_length + 1, utf8_input_byte_count + 1);

		byte* utf8_input_bytes;
		byte* original_utf8_input_bytes;
		if(input_buf_size > Util.StackAllocationSizeLimit) {
			utf8_input_bytes = Util.Allocate(input_buf_size);
			original_utf8_input_bytes = Util.Allocate(input_buf_size);
		} else {
			var input_stack_bytes = stackalloc byte[input_buf_size];
			utf8_input_bytes = input_stack_bytes;
			var original_input_stack_bytes = stackalloc byte[input_buf_size];
			original_utf8_input_bytes = original_input_stack_bytes;
		}
		Util.GetUtf8(input, utf8_input_bytes, input_buf_size);
		var clear_bytes_count = (uint)(input_buf_size - utf8_input_byte_count);
		Unsafe.InitBlockUnaligned(utf8_input_bytes + utf8_input_byte_count, 0, clear_bytes_count);
		Unsafe.CopyBlock(original_utf8_input_bytes, utf8_input_bytes, (uint)input_buf_size);

		var result = ImGuiNative.igInputTextWithHint(
			utf8_label_bytes,
			utf8HintBytes,
			utf8_input_bytes,
			(uint)input_buf_size,
			flags,
			callback,
			user_data.ToPointer());
		if(!Util.AreStringsEqual(original_utf8_input_bytes, input_buf_size, utf8_input_bytes)) {
			input = Util.StringFromPtr(utf8_input_bytes);
		}

		if(utf8_label_byte_count > Util.StackAllocationSizeLimit) {
			Util.Free(utf8_label_bytes);
		}
		if(utf8HintByteCount > Util.StackAllocationSizeLimit) {
			Util.Free(utf8HintBytes);
		}
		if(input_buf_size > Util.StackAllocationSizeLimit) {
			Util.Free(utf8_input_bytes);
			Util.Free(original_utf8_input_bytes);
		}

		return result != 0;
	}

	public static Vector2 CalcTextSize(string text)
		=> CalcTextSizeImpl(text);

	public static Vector2 CalcTextSize(string text, int start)
		=> CalcTextSizeImpl(text, start);

	public static Vector2 CalcTextSize(string text, float wrapWidth)
		=> CalcTextSizeImpl(text, wrap_width: wrapWidth);

	public static Vector2 CalcTextSize(string text, bool hideTextAfterDoubleHash)
		=> CalcTextSizeImpl(text, hide_text_after_double_hash: hideTextAfterDoubleHash);

	public static Vector2 CalcTextSize(string text, int start, int length)
		=> CalcTextSizeImpl(text, start, length);

	public static Vector2 CalcTextSize(string text, int start, bool hideTextAfterDoubleHash)
		=> CalcTextSizeImpl(text, start, hide_text_after_double_hash: hideTextAfterDoubleHash);

	public static Vector2 CalcTextSize(string text, int start, float wrapWidth)
		=> CalcTextSizeImpl(text, start, wrap_width: wrapWidth);

	public static Vector2 CalcTextSize(string text, bool hideTextAfterDoubleHash, float wrapWidth)
		=> CalcTextSizeImpl(text, hide_text_after_double_hash: hideTextAfterDoubleHash, wrap_width: wrapWidth);

	public static Vector2 CalcTextSize(string text, int start, int length, bool hideTextAfterDoubleHash)
		=> CalcTextSizeImpl(text, start, length, hideTextAfterDoubleHash);

	public static Vector2 CalcTextSize(string text, int start, int length, float wrapWidth)
		=> CalcTextSizeImpl(text, start, length, wrap_width: wrapWidth);

	public static Vector2 CalcTextSize(string text, int start, int length, bool hideTextAfterDoubleHash, float wrapWidth)
		=> CalcTextSizeImpl(text, start, length, hideTextAfterDoubleHash, wrapWidth);

	static Vector2 CalcTextSizeImpl(
		string text,
		int start = 0,
		int? length = null,
		bool hide_text_after_double_hash = false,
		float wrap_width = -1.0f) {
		Vector2 ret;
		byte* native_text_start = null;
		byte* native_text_end = null;
		var text_byte_count = 0;
		if(text != null) {

			var text_to_copy_len = length ?? text.Length;
			text_byte_count = Util.CalcSizeInUtf8(text, start, text_to_copy_len);
			if(text_byte_count > Util.StackAllocationSizeLimit) {
				native_text_start = Util.Allocate(text_byte_count + 1);
			} else {
				var native_text_stack_bytes = stackalloc byte[text_byte_count + 1];
				native_text_start = native_text_stack_bytes;
			}

			var native_text_offset = Util.GetUtf8(text, start, text_to_copy_len, native_text_start, text_byte_count);
			native_text_start[native_text_offset] = 0;
			native_text_end = native_text_start + native_text_offset;
		}

		ImGuiNative.igCalcTextSize(&ret, native_text_start, native_text_end, *(byte*)&hide_text_after_double_hash, wrap_width);
		if(text_byte_count > Util.StackAllocationSizeLimit) {
			Util.Free(native_text_start);
		}

		return ret;
	}

	public static bool InputText(
		string label,
		IntPtr buf,
		uint buf_size) => InputText(label, buf, buf_size, 0, null, IntPtr.Zero);

	public static bool InputText(
		string label,
		IntPtr buf,
		uint buf_size,
		ImGuiInputTextFlags flags) => InputText(label, buf, buf_size, flags, null, IntPtr.Zero);

	public static bool InputText(
		string label,
		IntPtr buf,
		uint buf_size,
		ImGuiInputTextFlags flags,
		ImGuiInputTextCallback callback) => InputText(label, buf, buf_size, flags, callback, IntPtr.Zero);

	public static bool InputText(
		string label,
		IntPtr buf,
		uint buf_size,
		ImGuiInputTextFlags flags,
		ImGuiInputTextCallback callback,
		IntPtr user_data) {
		var utf8_label_byte_count = Encoding.UTF8.GetByteCount(label);
		byte* utf8_label_bytes;
		if(utf8_label_byte_count > Util.StackAllocationSizeLimit) {
			utf8_label_bytes = Util.Allocate(utf8_label_byte_count + 1);
		} else {
			var stack_ptr = stackalloc byte[utf8_label_byte_count + 1];
			utf8_label_bytes = stack_ptr;
		}
		Util.GetUtf8(label, utf8_label_bytes, utf8_label_byte_count);

		var ret = ImGuiNative.igInputText(utf8_label_bytes, (byte*)buf.ToPointer(), buf_size, flags, callback, user_data.ToPointer()) != 0;

		if(utf8_label_byte_count > Util.StackAllocationSizeLimit) {
			Util.Free(utf8_label_bytes);
		}

		return ret;
	}

	public static bool Begin(string name, ImGuiWindowFlags flags) {
		var utf8_name_byte_count = Encoding.UTF8.GetByteCount(name);
		byte* utf8_name_bytes;
		if(utf8_name_byte_count > Util.StackAllocationSizeLimit) {
			utf8_name_bytes = Util.Allocate(utf8_name_byte_count + 1);
		} else {
			var stack_ptr = stackalloc byte[utf8_name_byte_count + 1];
			utf8_name_bytes = stack_ptr;
		}
		Util.GetUtf8(name, utf8_name_bytes, utf8_name_byte_count);

		byte* p_open = null;
		var ret = ImGuiNative.igBegin(utf8_name_bytes, p_open, flags);

		if(utf8_name_byte_count > Util.StackAllocationSizeLimit) {
			Util.Free(utf8_name_bytes);
		}

		return ret != 0;
	}

	public static bool MenuItem(string label, bool enabled) => MenuItem(label, string.Empty, false, enabled);
}
