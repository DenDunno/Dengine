using System;
using System.Numerics;
using ImGuiNET;

namespace ImGuizmoNET;

public static unsafe partial class ImGuizmo {
	public static void AllowAxisFlip(bool value) {
		var native_value = value ? (byte)1 : (byte)0;
		ImGuizmoNative.ImGuizmo_AllowAxisFlip(native_value);
	}
	public static void BeginFrame() => ImGuizmoNative.ImGuizmo_BeginFrame();
	public static void DecomposeMatrixToComponents(ref float matrix, ref float translation, ref float rotation, ref float scale) {
		fixed(float* native_matrix = &matrix) {
			fixed(float* native_translation = &translation) {
				fixed(float* native_rotation = &rotation) {
					fixed(float* native_scale = &scale) {
						ImGuizmoNative.ImGuizmo_DecomposeMatrixToComponents(native_matrix, native_translation, native_rotation, native_scale);
					}
				}
			}
		}
	}
	public static void DrawCubes(ref float view, ref float projection, ref float matrices, int matrix_count) {
		fixed(float* native_view = &view) {
			fixed(float* native_projection = &projection) {
				fixed(float* native_matrices = &matrices) {
					ImGuizmoNative.ImGuizmo_DrawCubes(native_view, native_projection, native_matrices, matrix_count);
				}
			}
		}
	}
	public static void DrawGrid(ref float view, ref float projection, ref float matrix, float grid_size) {
		fixed(float* native_view = &view) {
			fixed(float* native_projection = &projection) {
				fixed(float* native_matrix = &matrix) {
					ImGuizmoNative.ImGuizmo_DrawGrid(native_view, native_projection, native_matrix, grid_size);
				}
			}
		}
	}
	public static void Enable(bool enable) {
		var native_enable = enable ? (byte)1 : (byte)0;
		ImGuizmoNative.ImGuizmo_Enable(native_enable);
	}
	public static bool IsOver() {
		var ret = ImGuizmoNative.ImGuizmo_IsOver_Nil();
		return ret != 0;
	}
	public static bool IsOver(TransformOperation op) {
		var ret = ImGuizmoNative.ImGuizmo_IsOver_OPERATION(op);
		return ret != 0;
	}
	public static bool IsUsing() {
		var ret = ImGuizmoNative.ImGuizmo_IsUsing();
		return ret != 0;
	}
	public static bool Manipulate(ref float view, ref float projection, TransformOperation operation, TransformMode mode, ref float matrix) {
		float* delta_matrix = null;
		float* snap = null;
		float* localbounds = null;
		float* bounds_snap = null;
		fixed(float* native_view = &view) {
			fixed(float* native_projection = &projection) {
				fixed(float* native_matrix = &matrix) {
					var ret = ImGuizmoNative.ImGuizmo_Manipulate(native_view, native_projection, operation, mode, native_matrix, delta_matrix, snap, localbounds, bounds_snap);
					return ret != 0;
				}
			}
		}
	}
	public static bool Manipulate(ref float view, ref float projection, TransformOperation operation, TransformMode mode, ref float matrix, ref float delta_matrix) {
		float* snap = null;
		float* localbounds = null;
		float* bounds_snap = null;
		fixed(float* native_view = &view) {
			fixed(float* native_projection = &projection) {
				fixed(float* native_matrix = &matrix) {
					fixed(float* native_delta_matrix = &delta_matrix) {
						var ret = ImGuizmoNative.ImGuizmo_Manipulate(native_view, native_projection, operation, mode, native_matrix, native_delta_matrix, snap, localbounds, bounds_snap);
						return ret != 0;
					}
				}
			}
		}
	}
	public static bool Manipulate(ref float view, ref float projection, TransformOperation operation, TransformMode mode, ref float matrix, ref float delta_matrix, ref float snap) {
		float* localbounds = null;
		float* bounds_snap = null;
		fixed(float* native_view = &view) {
			fixed(float* native_projection = &projection) {
				fixed(float* native_matrix = &matrix) {
					fixed(float* native_delta_matrix = &delta_matrix) {
						fixed(float* native_snap = &snap) {
							var ret = ImGuizmoNative.ImGuizmo_Manipulate(native_view, native_projection, operation, mode, native_matrix, native_delta_matrix, native_snap, localbounds, bounds_snap);
							return ret != 0;
						}
					}
				}
			}
		}
	}
	public static bool Manipulate(ref float view, ref float projection, TransformOperation operation, TransformMode mode, ref float matrix, ref float delta_matrix, ref float snap, ref float localbounds) {
		float* bounds_snap = null;
		fixed(float* native_view = &view) {
			fixed(float* native_projection = &projection) {
				fixed(float* native_matrix = &matrix) {
					fixed(float* native_delta_matrix = &delta_matrix) {
						fixed(float* native_snap = &snap) {
							fixed(float* native_localbounds = &localbounds) {
								var ret = ImGuizmoNative.ImGuizmo_Manipulate(native_view, native_projection, operation, mode, native_matrix, native_delta_matrix, native_snap, native_localbounds, bounds_snap);
								return ret != 0;
							}
						}
					}
				}
			}
		}
	}
	public static bool Manipulate(ref float view, ref float projection, TransformOperation operation, TransformMode mode, ref float matrix, ref float delta_matrix, ref float snap, ref float localbounds, ref float bounds_snap) {
		fixed(float* native_view = &view) {
			fixed(float* native_projection = &projection) {
				fixed(float* native_matrix = &matrix) {
					fixed(float* native_delta_matrix = &delta_matrix) {
						fixed(float* native_snap = &snap) {
							fixed(float* native_localbounds = &localbounds) {
								fixed(float* native_bounds_snap = &bounds_snap) {
									var ret = ImGuizmoNative.ImGuizmo_Manipulate(native_view, native_projection, operation, mode, native_matrix, native_delta_matrix, native_snap, native_localbounds, native_bounds_snap);
									return ret != 0;
								}
							}
						}
					}
				}
			}
		}
	}
	public static void RecomposeMatrixFromComponents(ref float translation, ref float rotation, ref float scale, ref float matrix) {
		fixed(float* native_translation = &translation) {
			fixed(float* native_rotation = &rotation) {
				fixed(float* native_scale = &scale) {
					fixed(float* native_matrix = &matrix) {
						ImGuizmoNative.ImGuizmo_RecomposeMatrixFromComponents(native_translation, native_rotation, native_scale, native_matrix);
					}
				}
			}
		}
	}
	public static void SetDrawlist() {
		ImDrawList* drawlist = null;
		ImGuizmoNative.ImGuizmo_SetDrawlist(drawlist);
	}
	public static void SetDrawlist(ImDrawListPtr drawlist) {
		var native_drawlist = drawlist.NativePtr;
		ImGuizmoNative.ImGuizmo_SetDrawlist(native_drawlist);
	}
	public static void SetGizmoSizeClipSpace(float value) => ImGuizmoNative.ImGuizmo_SetGizmoSizeClipSpace(value);
	public static void SetID(int id) => ImGuizmoNative.ImGuizmo_SetID(id);
	public static void SetImGuiContext(IntPtr ctx) => ImGuizmoNative.ImGuizmo_SetImGuiContext(ctx);
	public static void SetOrthographic(bool is_orthographic) {
		var native_is_orthographic = is_orthographic ? (byte)1 : (byte)0;
		ImGuizmoNative.ImGuizmo_SetOrthographic(native_is_orthographic);
	}
	public static void SetRect(float x, float y, float width, float height) => ImGuizmoNative.ImGuizmo_SetRect(x, y, width, height);
	public static void ViewManipulate(ref float view, float length, Vector2 position, Vector2 size, uint background_color) {
		fixed(float* native_view = &view) {
			ImGuizmoNative.ImGuizmo_ViewManipulate(native_view, length, position, size, background_color);
		}
	}
}
