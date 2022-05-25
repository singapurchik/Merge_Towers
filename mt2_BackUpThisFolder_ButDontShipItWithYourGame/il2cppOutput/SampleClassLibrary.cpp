#include "pch-cpp.hpp"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif


#include <limits>
#include <stdint.h>



// System.Collections.Generic.Dictionary`2<System.Int32,System.Object>
struct Dictionary_2_tA75D1125AC9BE8F005BA9B868B373398E643C907;
// System.Collections.Generic.Dictionary`2<System.Int32,System.String>
struct Dictionary_2_t291007AFA4B4075BA87D802F2E42017CB8C857C9;
// System.Collections.Generic.IEqualityComparer`1<System.Int32>
struct IEqualityComparer_1_tDBFC8496F14612776AF930DBF84AFE7D06D1F0E9;
// System.Collections.Generic.Dictionary`2/KeyCollection<System.Int32,System.String>
struct KeyCollection_t78693409E5147276425329CB69C1414D43C8CCE5;
// System.Collections.Generic.Dictionary`2/ValueCollection<System.Int32,System.String>
struct ValueCollection_tE9183007A5785689F86BDBB22CB72D19AB5E1192;
// System.Collections.Generic.Dictionary`2/Entry<System.Int32,System.String>[]
struct EntryU5BU5D_t8551361338B9BF5705CA61FFE9EA2EDEA1B1EF34;
// System.Int32[]
struct Int32U5BU5D_t19C97395396A72ECAF310612F0760F165060314C;
// SampleClassLibrary.SampleExternalClass
struct SampleExternalClass_t76EE8528CD66096BCF05C74A84539B6508CCF001;
// System.String
struct String_t;

IL2CPP_EXTERN_C RuntimeClass* Dictionary_2_t291007AFA4B4075BA87D802F2E42017CB8C857C9_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C const RuntimeMethod* Dictionary_2__ctor_mC854597C0C338BBA12EE451456D8658DF6D01BD4_RuntimeMethod_var;


IL2CPP_EXTERN_C_BEGIN
IL2CPP_EXTERN_C_END

#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// <Module>
struct U3CModuleU3E_t5E736B2FF6F26F7D5F9D08BD0D9453928D8CEFE9 
{
};

// System.Collections.Generic.Dictionary`2<System.Int32,System.String>
struct Dictionary_2_t291007AFA4B4075BA87D802F2E42017CB8C857C9  : public RuntimeObject
{
	// System.Int32[] System.Collections.Generic.Dictionary`2::_buckets
	Int32U5BU5D_t19C97395396A72ECAF310612F0760F165060314C* ____buckets_0;
	// System.Collections.Generic.Dictionary`2/Entry<TKey,TValue>[] System.Collections.Generic.Dictionary`2::_entries
	EntryU5BU5D_t8551361338B9BF5705CA61FFE9EA2EDEA1B1EF34* ____entries_1;
	// System.Int32 System.Collections.Generic.Dictionary`2::_count
	int32_t ____count_2;
	// System.Int32 System.Collections.Generic.Dictionary`2::_freeList
	int32_t ____freeList_3;
	// System.Int32 System.Collections.Generic.Dictionary`2::_freeCount
	int32_t ____freeCount_4;
	// System.Int32 System.Collections.Generic.Dictionary`2::_version
	int32_t ____version_5;
	// System.Collections.Generic.IEqualityComparer`1<TKey> System.Collections.Generic.Dictionary`2::_comparer
	RuntimeObject* ____comparer_6;
	// System.Collections.Generic.Dictionary`2/KeyCollection<TKey,TValue> System.Collections.Generic.Dictionary`2::_keys
	KeyCollection_t78693409E5147276425329CB69C1414D43C8CCE5* ____keys_7;
	// System.Collections.Generic.Dictionary`2/ValueCollection<TKey,TValue> System.Collections.Generic.Dictionary`2::_values
	ValueCollection_tE9183007A5785689F86BDBB22CB72D19AB5E1192* ____values_8;
	// System.Object System.Collections.Generic.Dictionary`2::_syncRoot
	RuntimeObject* ____syncRoot_9;
};
struct Il2CppArrayBounds;

// SampleClassLibrary.SampleExternalClass
struct SampleExternalClass_t76EE8528CD66096BCF05C74A84539B6508CCF001  : public RuntimeObject
{
	// System.String SampleClassLibrary.SampleExternalClass::<SampleString>k__BackingField
	String_t* ___U3CSampleStringU3Ek__BackingField_0;
	// System.Collections.Generic.Dictionary`2<System.Int32,System.String> SampleClassLibrary.SampleExternalClass::<SampleDictionary>k__BackingField
	Dictionary_2_t291007AFA4B4075BA87D802F2E42017CB8C857C9* ___U3CSampleDictionaryU3Ek__BackingField_1;
};

// System.String
struct String_t  : public RuntimeObject
{
	// System.Int32 System.String::_stringLength
	int32_t ____stringLength_4;
	// System.Char System.String::_firstChar
	Il2CppChar ____firstChar_5;
};

struct String_t_StaticFields
{
	// System.String System.String::Empty
	String_t* ___Empty_6;
};

// System.ValueType
struct ValueType_t6D9B272BD21782F0A9A14F2E41F85A50E97A986F  : public RuntimeObject
{
};
// Native definition for P/Invoke marshalling of System.ValueType
struct ValueType_t6D9B272BD21782F0A9A14F2E41F85A50E97A986F_marshaled_pinvoke
{
};
// Native definition for COM marshalling of System.ValueType
struct ValueType_t6D9B272BD21782F0A9A14F2E41F85A50E97A986F_marshaled_com
{
};

// System.Void
struct Void_t4861ACF8F4594C3437BB48B6E56783494B843915 
{
	union
	{
		struct
		{
		};
		uint8_t Void_t4861ACF8F4594C3437BB48B6E56783494B843915__padding[1];
	};
};
#ifdef __clang__
#pragma clang diagnostic pop
#endif


// System.Void System.Collections.Generic.Dictionary`2<System.Int32,System.Object>::.ctor()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Dictionary_2__ctor_m92E9AB321FBD7147CA109C822D99C8B0610C27B7_gshared (Dictionary_2_tA75D1125AC9BE8F005BA9B868B373398E643C907* __this, const RuntimeMethod* method) ;

// System.Void System.Object::.ctor()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Object__ctor_mE837C6B9FA8C6D5D109F4B2EC885D79919AC0EA2 (RuntimeObject* __this, const RuntimeMethod* method) ;
// System.Void System.Collections.Generic.Dictionary`2<System.Int32,System.String>::.ctor()
inline void Dictionary_2__ctor_mC854597C0C338BBA12EE451456D8658DF6D01BD4 (Dictionary_2_t291007AFA4B4075BA87D802F2E42017CB8C857C9* __this, const RuntimeMethod* method)
{
	((  void (*) (Dictionary_2_t291007AFA4B4075BA87D802F2E42017CB8C857C9*, const RuntimeMethod*))Dictionary_2__ctor_m92E9AB321FBD7147CA109C822D99C8B0610C27B7_gshared)(__this, method);
}
// System.Void SampleClassLibrary.SampleExternalClass::set_SampleDictionary(System.Collections.Generic.Dictionary`2<System.Int32,System.String>)
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void SampleExternalClass_set_SampleDictionary_mF5CE4D981FDCDEA00235CC0B322632C3A7DF28B1_inline (SampleExternalClass_t76EE8528CD66096BCF05C74A84539B6508CCF001* __this, Dictionary_2_t291007AFA4B4075BA87D802F2E42017CB8C857C9* ___value0, const RuntimeMethod* method) ;
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
// System.String SampleClassLibrary.SampleExternalClass::get_SampleString()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR String_t* SampleExternalClass_get_SampleString_m0193F593FF1DC18FC3B582342A3B71EFCBBDCC43 (SampleExternalClass_t76EE8528CD66096BCF05C74A84539B6508CCF001* __this, const RuntimeMethod* method) 
{
	{
		String_t* L_0 = __this->___U3CSampleStringU3Ek__BackingField_0;
		return L_0;
	}
}
// System.Void SampleClassLibrary.SampleExternalClass::set_SampleString(System.String)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void SampleExternalClass_set_SampleString_m3A78B20F14BCAD45B140816DEFFB0350EA733E96 (SampleExternalClass_t76EE8528CD66096BCF05C74A84539B6508CCF001* __this, String_t* ___value0, const RuntimeMethod* method) 
{
	{
		String_t* L_0 = ___value0;
		__this->___U3CSampleStringU3Ek__BackingField_0 = L_0;
		Il2CppCodeGenWriteBarrier((void**)(&__this->___U3CSampleStringU3Ek__BackingField_0), (void*)L_0);
		return;
	}
}
// System.Collections.Generic.Dictionary`2<System.Int32,System.String> SampleClassLibrary.SampleExternalClass::get_SampleDictionary()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Dictionary_2_t291007AFA4B4075BA87D802F2E42017CB8C857C9* SampleExternalClass_get_SampleDictionary_m416544E10BA350C17A66C485974EBFD798A9CAE6 (SampleExternalClass_t76EE8528CD66096BCF05C74A84539B6508CCF001* __this, const RuntimeMethod* method) 
{
	{
		Dictionary_2_t291007AFA4B4075BA87D802F2E42017CB8C857C9* L_0 = __this->___U3CSampleDictionaryU3Ek__BackingField_1;
		return L_0;
	}
}
// System.Void SampleClassLibrary.SampleExternalClass::set_SampleDictionary(System.Collections.Generic.Dictionary`2<System.Int32,System.String>)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void SampleExternalClass_set_SampleDictionary_mF5CE4D981FDCDEA00235CC0B322632C3A7DF28B1 (SampleExternalClass_t76EE8528CD66096BCF05C74A84539B6508CCF001* __this, Dictionary_2_t291007AFA4B4075BA87D802F2E42017CB8C857C9* ___value0, const RuntimeMethod* method) 
{
	{
		Dictionary_2_t291007AFA4B4075BA87D802F2E42017CB8C857C9* L_0 = ___value0;
		__this->___U3CSampleDictionaryU3Ek__BackingField_1 = L_0;
		Il2CppCodeGenWriteBarrier((void**)(&__this->___U3CSampleDictionaryU3Ek__BackingField_1), (void*)L_0);
		return;
	}
}
// System.Void SampleClassLibrary.SampleExternalClass::.ctor()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void SampleExternalClass__ctor_mD89F6157A76DA622C7BC772907D887F157518D7B (SampleExternalClass_t76EE8528CD66096BCF05C74A84539B6508CCF001* __this, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Dictionary_2__ctor_mC854597C0C338BBA12EE451456D8658DF6D01BD4_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Dictionary_2_t291007AFA4B4075BA87D802F2E42017CB8C857C9_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		Object__ctor_mE837C6B9FA8C6D5D109F4B2EC885D79919AC0EA2(__this, NULL);
		Dictionary_2_t291007AFA4B4075BA87D802F2E42017CB8C857C9* L_0 = (Dictionary_2_t291007AFA4B4075BA87D802F2E42017CB8C857C9*)il2cpp_codegen_object_new(Dictionary_2_t291007AFA4B4075BA87D802F2E42017CB8C857C9_il2cpp_TypeInfo_var);
		NullCheck(L_0);
		Dictionary_2__ctor_mC854597C0C338BBA12EE451456D8658DF6D01BD4(L_0, Dictionary_2__ctor_mC854597C0C338BBA12EE451456D8658DF6D01BD4_RuntimeMethod_var);
		SampleExternalClass_set_SampleDictionary_mF5CE4D981FDCDEA00235CC0B322632C3A7DF28B1_inline(__this, L_0, NULL);
		return;
	}
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void SampleExternalClass_set_SampleDictionary_mF5CE4D981FDCDEA00235CC0B322632C3A7DF28B1_inline (SampleExternalClass_t76EE8528CD66096BCF05C74A84539B6508CCF001* __this, Dictionary_2_t291007AFA4B4075BA87D802F2E42017CB8C857C9* ___value0, const RuntimeMethod* method) 
{
	{
		Dictionary_2_t291007AFA4B4075BA87D802F2E42017CB8C857C9* L_0 = ___value0;
		__this->___U3CSampleDictionaryU3Ek__BackingField_1 = L_0;
		Il2CppCodeGenWriteBarrier((void**)(&__this->___U3CSampleDictionaryU3Ek__BackingField_1), (void*)L_0);
		return;
	}
}
