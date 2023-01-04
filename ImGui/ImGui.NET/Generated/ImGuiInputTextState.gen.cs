using System;
using System.Runtime.CompilerServices;

namespace ImGuiNET;

public unsafe partial struct ImGuiInputTextState {
	public uint ID;
	public int CurLenW;
	public int CurLenA;
	public ImVector TextW;
	public ImVector TextA;
	public ImVector InitialTextA;
	public byte TextAIsValid;
	public int BufCapacityA;
	public float ScrollX;
	public STB_TexteditState Stb;
	public float CursorAnim;
	public byte CursorFollow;
	public byte SelectedAllMouseLock;
	public byte Edited;
	public ImGuiInputTextFlags Flags;
	public void* UserCallbackData;
}
public unsafe partial struct ImGuiInputTextStatePtr {
	public ImGuiInputTextState* NativePtr { get; }
	public ImGuiInputTextStatePtr(ImGuiInputTextState* nativePtr) => NativePtr = nativePtr;
	public ImGuiInputTextStatePtr(IntPtr nativePtr) => NativePtr = (ImGuiInputTextState*)nativePtr;
	public static implicit operator ImGuiInputTextStatePtr(ImGuiInputTextState* nativePtr) => new(nativePtr);
	public static implicit operator ImGuiInputTextState*(ImGuiInputTextStatePtr wrappedPtr) => wrappedPtr.NativePtr;
	public static implicit operator ImGuiInputTextStatePtr(IntPtr nativePtr) => new(nativePtr);
	public ref uint ID => ref Unsafe.AsRef<uint>(&NativePtr->ID);
	public ref int CurLenW => ref Unsafe.AsRef<int>(&NativePtr->CurLenW);
	public ref int CurLenA => ref Unsafe.AsRef<int>(&NativePtr->CurLenA);
	public ImVector<ushort> TextW => new(NativePtr->TextW);
	public ImVector<byte> TextA => new(NativePtr->TextA);
	public ImVector<byte> InitialTextA => new(NativePtr->InitialTextA);
	public ref bool TextAIsValid => ref Unsafe.AsRef<bool>(&NativePtr->TextAIsValid);
	public ref int BufCapacityA => ref Unsafe.AsRef<int>(&NativePtr->BufCapacityA);
	public ref float ScrollX => ref Unsafe.AsRef<float>(&NativePtr->ScrollX);
	public ref STB_TexteditState Stb => ref Unsafe.AsRef<STB_TexteditState>(&NativePtr->Stb);
	public ref float CursorAnim => ref Unsafe.AsRef<float>(&NativePtr->CursorAnim);
	public ref bool CursorFollow => ref Unsafe.AsRef<bool>(&NativePtr->CursorFollow);
	public ref bool SelectedAllMouseLock => ref Unsafe.AsRef<bool>(&NativePtr->SelectedAllMouseLock);
	public ref bool Edited => ref Unsafe.AsRef<bool>(&NativePtr->Edited);
	public ref ImGuiInputTextFlags Flags => ref Unsafe.AsRef<ImGuiInputTextFlags>(&NativePtr->Flags);
	public IntPtr UserCallbackData { get => (IntPtr)NativePtr->UserCallbackData; set => NativePtr->UserCallbackData = (void*)value; }
	public void ClearFreeMemory() => ImGuiNative.ImGuiInputTextState_ClearFreeMemory((ImGuiInputTextState*)(NativePtr));
	public void ClearSelection() => ImGuiNative.ImGuiInputTextState_ClearSelection((ImGuiInputTextState*)(NativePtr));
	public void ClearText() => ImGuiNative.ImGuiInputTextState_ClearText((ImGuiInputTextState*)(NativePtr));
	public void CursorAnimReset() => ImGuiNative.ImGuiInputTextState_CursorAnimReset((ImGuiInputTextState*)(NativePtr));
	public void CursorClamp() => ImGuiNative.ImGuiInputTextState_CursorClamp((ImGuiInputTextState*)(NativePtr));
	public void Destroy() => ImGuiNative.ImGuiInputTextState_destroy((ImGuiInputTextState*)(NativePtr));
	public int GetCursorPos() {
		var ret = ImGuiNative.ImGuiInputTextState_GetCursorPos((ImGuiInputTextState*)(NativePtr));
		return ret;
	}
	public int GetRedoAvailCount() {
		var ret = ImGuiNative.ImGuiInputTextState_GetRedoAvailCount((ImGuiInputTextState*)(NativePtr));
		return ret;
	}
	public int GetSelectionEnd() {
		var ret = ImGuiNative.ImGuiInputTextState_GetSelectionEnd((ImGuiInputTextState*)(NativePtr));
		return ret;
	}
	public int GetSelectionStart() {
		var ret = ImGuiNative.ImGuiInputTextState_GetSelectionStart((ImGuiInputTextState*)(NativePtr));
		return ret;
	}
	public int GetUndoAvailCount() {
		var ret = ImGuiNative.ImGuiInputTextState_GetUndoAvailCount((ImGuiInputTextState*)(NativePtr));
		return ret;
	}
	public bool HasSelection() {
		var ret = ImGuiNative.ImGuiInputTextState_HasSelection((ImGuiInputTextState*)(NativePtr));
		return ret != 0;
	}
	public void OnKeyPressed(int key) => ImGuiNative.ImGuiInputTextState_OnKeyPressed((ImGuiInputTextState*)(NativePtr), key);
	public void SelectAll() => ImGuiNative.ImGuiInputTextState_SelectAll((ImGuiInputTextState*)(NativePtr));
}
