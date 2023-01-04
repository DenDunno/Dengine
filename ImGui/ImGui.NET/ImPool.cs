using System;
using System.Runtime.CompilerServices;

namespace ImGuiNET;

public unsafe struct ImPool {
	public readonly int Size;
	public readonly int Capacity;
	public readonly IntPtr Data;

	public ImPool(int size, int capacity, IntPtr data) {
		Size = size;
		Capacity = capacity;
		Data = data;
	}

	public ref T Ref<T>(int index) => ref Unsafe.AsRef<T>((byte*)Data + index * Unsafe.SizeOf<T>());

	public IntPtr Address<T>(int index) => (IntPtr)((byte*)Data + index * Unsafe.SizeOf<T>());
}

public unsafe struct ImPool<T> {
	public readonly int Size;
	public readonly int Capacity;
	public readonly IntPtr Data;

	public ImPool(ImPool pool) {
		Size = pool.Size;
		Capacity = pool.Capacity;
		Data = pool.Data;
	}

	public ImPool(int size, int capacity, IntPtr data) {
		Size = size;
		Capacity = capacity;
		Data = data;
	}

	public ref T this[int index] => ref Unsafe.AsRef<T>((byte*)Data + index * Unsafe.SizeOf<T>());
}

public unsafe struct ImPtrPool<T> {
	public readonly int Size;
	public readonly int Capacity;
	public readonly IntPtr Data;
	readonly int stride;

	public ImPtrPool(ImPool pool, int stride)
		: this(pool.Size, pool.Capacity, pool.Data, stride) { }

	public ImPtrPool(int size, int capacity, IntPtr data, int stride) {
		Size = size;
		Capacity = capacity;
		Data = data;
		this.stride = stride;
	}

	public T this[int index] {
		get {
			var address = (byte*)Data + index * stride;
			var ret = Unsafe.Read<T>(&address);
			return ret;
		}
	}
}
