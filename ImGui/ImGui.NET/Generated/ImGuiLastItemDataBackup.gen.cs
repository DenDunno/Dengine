using System;
using System.Runtime.CompilerServices;

namespace ImGuiNET;

public unsafe partial struct ImGuiLastItemDataBackup {
	public uint LastItemId;
	public ImGuiItemStatusFlags LastItemStatusFlags;
	public ImRect LastItemRect;
	public ImRect LastItemDisplayRect;
}
public unsafe partial struct ImGuiLastItemDataBackupPtr {
	public ImGuiLastItemDataBackup* NativePtr { get; }
	public ImGuiLastItemDataBackupPtr(ImGuiLastItemDataBackup* nativePtr) => NativePtr = nativePtr;
	public ImGuiLastItemDataBackupPtr(IntPtr nativePtr) => NativePtr = (ImGuiLastItemDataBackup*)nativePtr;
	public static implicit operator ImGuiLastItemDataBackupPtr(ImGuiLastItemDataBackup* nativePtr) => new(nativePtr);
	public static implicit operator ImGuiLastItemDataBackup*(ImGuiLastItemDataBackupPtr wrappedPtr) => wrappedPtr.NativePtr;
	public static implicit operator ImGuiLastItemDataBackupPtr(IntPtr nativePtr) => new(nativePtr);
	public ref uint LastItemId => ref Unsafe.AsRef<uint>(&NativePtr->LastItemId);
	public ref ImGuiItemStatusFlags LastItemStatusFlags => ref Unsafe.AsRef<ImGuiItemStatusFlags>(&NativePtr->LastItemStatusFlags);
	public ref ImRect LastItemRect => ref Unsafe.AsRef<ImRect>(&NativePtr->LastItemRect);
	public ref ImRect LastItemDisplayRect => ref Unsafe.AsRef<ImRect>(&NativePtr->LastItemDisplayRect);
	public void Backup() => ImGuiNative.ImGuiLastItemDataBackup_Backup((ImGuiLastItemDataBackup*)(NativePtr));
	public void Destroy() => ImGuiNative.ImGuiLastItemDataBackup_destroy((ImGuiLastItemDataBackup*)(NativePtr));
	public void Restore() => ImGuiNative.ImGuiLastItemDataBackup_Restore((ImGuiLastItemDataBackup*)(NativePtr));
}
