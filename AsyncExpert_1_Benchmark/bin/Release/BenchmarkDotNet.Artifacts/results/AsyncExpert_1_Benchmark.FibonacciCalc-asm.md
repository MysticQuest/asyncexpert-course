## .NET Framework 4.8.1 (4.8.9181.0), X86 LegacyJIT
```assembly
; AsyncExpert_1_Benchmark.FibonacciCalc.Recursive(UInt64)
M00_L00:
       push      ebp
       mov       ebp,esp
       push      edi
       push      esi
       push      ebx
       mov       esi,ecx
       cmp       dword ptr [ebp+0C],0
       jne       short M00_L01
       cmp       dword ptr [ebp+8],1
       je        short M00_L02
M00_L01:
       cmp       dword ptr [ebp+0C],0
       jne       short M00_L03
       cmp       dword ptr [ebp+8],2
       jne       short M00_L03
M00_L02:
       mov       eax,1
       xor       edx,edx
       pop       ebx
       pop       esi
       pop       edi
       pop       ebp
       ret       8
M00_L03:
       mov       eax,[ebp+8]
       mov       edx,[ebp+0C]
       sub       eax,2
       sbb       edx,0
       push      edx
       push      eax
       mov       ecx,esi
       call      dword ptr ds:[5734BF0]
       mov       ebx,eax
       mov       edi,edx
       mov       eax,[ebp+8]
       mov       edx,[ebp+0C]
       sub       eax,1
       sbb       edx,0
       push      edx
       push      eax
       mov       ecx,esi
       call      dword ptr ds:[5734BF0]
       add       eax,ebx
       adc       edx,edi
       pop       ebx
       pop       esi
       pop       edi
       pop       ebp
       ret       8
; Total bytes of code 105
```

## .NET Framework 4.8.1 (4.8.9181.0), X86 LegacyJIT
```assembly
; AsyncExpert_1_Benchmark.FibonacciCalc.RecursiveWithMemoization(UInt64)
M00_L00:
       push      ebp
       mov       ebp,esp
       push      edi
       push      esi
       push      ebx
       sub       esp,10
       mov       esi,ecx
       mov       ebx,[ebp+8]
       mov       edi,[ebp+0C]
       test      edi,edi
       jne       short M00_L01
       cmp       ebx,1
       je        short M00_L02
M00_L01:
       test      edi,edi
       jne       short M00_L03
       cmp       ebx,2
       jne       short M00_L03
M00_L02:
       mov       eax,1
       xor       edx,edx
       lea       esp,[ebp-0C]
       pop       ebx
       pop       esi
       pop       edi
       pop       ebp
       ret       8
M00_L03:
       mov       ecx,[esi+4]
       cmp       [ecx],al
       push      edi
       push      ebx
       call      dword ptr ds:[2764C6C]; System.Collections.Generic.Dictionary`2[[System.UInt64, mscorlib],[System.UInt64, mscorlib]].FindEntry(UInt64)
       test      eax,eax
       jl        short M00_L04
       mov       ecx,[esi+4]
       push      edi
       push      ebx
       cmp       [ecx],ecx
       call      dword ptr ds:[2764BC4]; System.Collections.Generic.Dictionary`2[[System.UInt64, mscorlib],[System.UInt64, mscorlib]].get_Item(UInt64)
       lea       esp,[ebp-0C]
       pop       ebx
       pop       esi
       pop       edi
       pop       ebp
       ret       8
M00_L04:
       mov       eax,ebx
       mov       edx,edi
       sub       eax,1
       sbb       edx,0
       push      edx
       push      eax
       mov       ecx,esi
       call      dword ptr ds:[2A44BFC]
       mov       [ebp-1C],eax
       mov       [ebp-18],edx
       mov       eax,ebx
       mov       edx,edi
       sub       eax,2
       sbb       edx,0
       push      edx
       push      eax
       mov       ecx,esi
       call      dword ptr ds:[2A44BFC]
       add       eax,[ebp-1C]
       adc       edx,[ebp-18]
       mov       [ebp-14],eax
       mov       [ebp-10],edx
       mov       ecx,[esi+4]
       cmp       [ecx],al
       push      edi
       push      ebx
       push      dword ptr [ebp-10]
       push      dword ptr [ebp-14]
       xor       edx,edx
       call      dword ptr ds:[2764C74]; System.Collections.Generic.Dictionary`2[[System.UInt64, mscorlib],[System.UInt64, mscorlib]].Insert(UInt64, UInt64, Boolean)
       mov       eax,[ebp-14]
       mov       edx,[ebp-10]
       lea       esp,[ebp-0C]
       pop       ebx
       pop       esi
       pop       edi
       pop       ebp
       ret       8
; Total bytes of code 187
```
```assembly
; System.Collections.Generic.Dictionary`2[[System.UInt64, mscorlib],[System.UInt64, mscorlib]].FindEntry(UInt64)
       push      ebp
       mov       ebp,esp
       push      edi
       push      esi
       push      ebx
       push      eax
       mov       edi,ecx
       mov       esi,[edi+4]
       test      esi,esi
       je        near ptr M01_L02
       mov       ecx,[edi+0C]
       push      dword ptr [ebp+0C]
       push      dword ptr [ebp+8]
       call      dword ptr ds:[2790030]
       and       eax,7FFFFFFF
       mov       [ebp-10],eax
       mov       esi,[edi+4]
       mov       ecx,[esi+4]
       cdq
       idiv      ecx
       cmp       edx,[esi+4]
       jae       short M01_L03
       mov       esi,[esi+edx*4+8]
       test      esi,esi
       jl        short M01_L02
       mov       ecx,[edi+8]
M01_L00:
       cmp       esi,[ecx+4]
       jae       short M01_L03
       lea       eax,[esi+esi*2]
       lea       eax,[ecx+eax*8+8]
       mov       eax,[eax]
       cmp       eax,[ebp-10]
       jne       short M01_L01
       mov       ebx,[edi+0C]
       lea       eax,[esi+esi*2]
       push      dword ptr [ecx+eax*8+14]
       push      dword ptr [ecx+eax*8+10]
       push      dword ptr [ebp+0C]
       push      dword ptr [ebp+8]
       mov       ecx,ebx
       call      dword ptr ds:[2790034]
       test      eax,eax
       je        short M01_L01
       mov       eax,esi
       pop       ecx
       pop       ebx
       pop       esi
       pop       edi
       pop       ebp
       ret       8
M01_L01:
       mov       ecx,[edi+8]
       cmp       esi,[ecx+4]
       jae       short M01_L03
       lea       eax,[esi+esi*2]
       lea       eax,[ecx+eax*8+8]
       mov       esi,[eax+4]
       test      esi,esi
       jge       short M01_L00
M01_L02:
       or        eax,0FFFFFFFF
       pop       ecx
       pop       ebx
       pop       esi
       pop       edi
       pop       ebp
       ret       8
M01_L03:
       call      CORINFO_HELP_RNGCHKFAIL
       int       3
; Total bytes of code 168
```
```assembly
; System.Collections.Generic.Dictionary`2[[System.UInt64, mscorlib],[System.UInt64, mscorlib]].get_Item(UInt64)
       push      ebp
       mov       ebp,esp
       push      esi
       sub       esp,8
       xor       eax,eax
       mov       [ebp-0C],eax
       mov       [ebp-8],eax
       mov       esi,ecx
       push      dword ptr [ebp+0C]
       push      dword ptr [ebp+8]
       mov       ecx,esi
       call      System.Collections.Generic.Dictionary`2[[System.UInt64, mscorlib],[System.UInt64, mscorlib]].FindEntry(UInt64)
       mov       ecx,eax
       test      ecx,ecx
       jl        short M02_L00
       mov       eax,[esi+8]
       cmp       ecx,[eax+4]
       jae       short M02_L01
       lea       edx,[ecx+ecx*2]
       lea       ecx,[eax+edx*8+8]
       mov       eax,[ecx+10]
       mov       edx,[ecx+14]
       lea       esp,[ebp-4]
       pop       esi
       pop       ebp
       ret       8
M02_L00:
       mov       ecx,offset MT_System.Collections.Generic.KeyNotFoundException
       call      CORINFO_HELP_NEWSFAST
       mov       esi,eax
       mov       ecx,esi
       call      dword ptr ds:[70A54E18]; System.Collections.Generic.KeyNotFoundException..ctor()
       mov       ecx,esi
       call      CORINFO_HELP_THROW
M02_L01:
       call      CORINFO_HELP_RNGCHKFAIL
       int       3
; Total bytes of code 98
```
```assembly
; System.Collections.Generic.Dictionary`2[[System.UInt64, mscorlib],[System.UInt64, mscorlib]].Insert(UInt64, UInt64, Boolean)
       push      ebp
       mov       ebp,esp
       push      edi
       push      esi
       push      ebx
       sub       esp,14
       mov       [ebp-10],edx
       mov       edi,ecx
       mov       ebx,[edi+4]
       test      ebx,ebx
       jne       short M03_L00
       mov       ecx,edi
       xor       edx,edx
       call      dword ptr ds:[2764C70]; System.Collections.Generic.Dictionary`2[[System.UInt64, mscorlib],[System.UInt64, mscorlib]].Initialize(Int32)
M03_L00:
       mov       ecx,[edi+0C]
       push      dword ptr [ebp+14]
       push      dword ptr [ebp+10]
       call      dword ptr ds:[2790038]
       and       eax,7FFFFFFF
       mov       [ebp-14],eax
       mov       ebx,[edi+4]
       mov       ecx,[ebx+4]
       cdq
       idiv      ecx
       mov       [ebp-18],edx
       xor       edx,edx
       mov       [ebp-1C],edx
       mov       eax,[ebp-18]
       cmp       eax,[ebx+4]
       jae       near ptr M03_L09
       mov       ebx,[ebx+eax*4+8]
       test      ebx,ebx
       jl        near ptr M03_L04
M03_L01:
       mov       esi,[edi+8]
       cmp       ebx,[esi+4]
       jae       near ptr M03_L09
       lea       eax,[ebx+ebx*2]
       lea       eax,[esi+eax*8+8]
       mov       eax,[eax]
       cmp       eax,[ebp-14]
       jne       short M03_L03
       mov       ecx,[edi+0C]
       lea       eax,[ebx+ebx*2]
       push      dword ptr [esi+eax*8+14]
       push      dword ptr [esi+eax*8+10]
       push      dword ptr [ebp+14]
       push      dword ptr [ebp+10]
       call      dword ptr ds:[279003C]
       test      eax,eax
       je        short M03_L03
       movzx     eax,byte ptr [ebp-10]
       test      eax,eax
       je        short M03_L02
       mov       ecx,0E
       call      System.ThrowHelper.ThrowArgumentException(System.ExceptionResource)
M03_L02:
       mov       esi,[edi+8]
       cmp       ebx,[esi+4]
       jae       near ptr M03_L09
       lea       eax,[ebx+ebx*2]
       lea       eax,[esi+eax*8+8]
       mov       ecx,[ebp+8]
       mov       edx,[ebp+0C]
       mov       [eax+10],ecx
       mov       [eax+14],edx
       inc       dword ptr [edi+20]
       lea       esp,[ebp-0C]
       pop       ebx
       pop       esi
       pop       edi
       pop       ebp
       ret       10
M03_L03:
       inc       dword ptr [ebp-1C]
       mov       esi,[edi+8]
       cmp       ebx,[esi+4]
       jae       near ptr M03_L09
       lea       eax,[ebx+ebx*2]
       lea       eax,[esi+eax*8+8]
       mov       ebx,[eax+4]
       test      ebx,ebx
       jge       near ptr M03_L01
M03_L04:
       cmp       dword ptr [edi+28],0
       jle       short M03_L05
       mov       eax,[edi+24]
       mov       [ebp-20],eax
       mov       esi,[edi+8]
       cmp       eax,[esi+4]
       jae       near ptr M03_L09
       lea       edx,[eax+eax*2]
       lea       edx,[esi+edx*8+8]
       mov       eax,[edx+4]
       mov       [edi+24],eax
       dec       dword ptr [edi+28]
       jmp       short M03_L07
M03_L05:
       mov       eax,[edi+1C]
       mov       esi,[edi+8]
       cmp       eax,[esi+4]
       jne       short M03_L06
       mov       ecx,[edi+1C]
       call      System.Collections.HashHelpers.ExpandPrime(Int32)
       mov       edx,eax
       push      0
       mov       ecx,edi
       call      dword ptr ds:[2764C7C]; System.Collections.Generic.Dictionary`2[[System.UInt64, mscorlib],[System.UInt64, mscorlib]].Resize(Int32, Boolean)
       mov       eax,[ebp-14]
       mov       ebx,[edi+4]
       mov       ecx,[ebx+4]
       cdq
       idiv      ecx
       mov       [ebp-18],edx
M03_L06:
       mov       eax,[edi+1C]
       mov       [ebp-20],eax
       inc       dword ptr [edi+1C]
M03_L07:
       mov       eax,[ebp-20]
       mov       esi,[edi+8]
       cmp       eax,[esi+4]
       jae       near ptr M03_L09
       lea       edx,[eax+eax*2]
       lea       edx,[esi+edx*8+8]
       mov       eax,[ebp-14]
       mov       [edx],eax
       mov       eax,[ebp-20]
       lea       eax,[eax+eax*2]
       mov       edx,[ebp-18]
       mov       ebx,[edi+4]
       cmp       edx,[ebx+4]
       jae       near ptr M03_L09
       mov       edx,[ebx+edx*4+8]
       mov       [esi+eax*8+0C],edx
       mov       eax,[ebp-20]
       lea       eax,[eax+eax*2]
       mov       ecx,[ebp+10]
       mov       edx,[ebp+14]
       mov       [esi+eax*8+10],ecx
       mov       [esi+eax*8+14],edx
       mov       eax,[ebp-20]
       lea       eax,[eax+eax*2]
       mov       ecx,[ebp+8]
       mov       edx,[ebp+0C]
       mov       [esi+eax*8+18],ecx
       mov       [esi+eax*8+1C],edx
       mov       eax,[ebp-18]
       mov       edx,[ebp-20]
       mov       [ebx+eax*4+8],edx
       inc       dword ptr [edi+20]
       cmp       dword ptr [ebp-1C],64
       jle       short M03_L08
       mov       ecx,[edi+0C]
       call      System.Collections.HashHelpers.IsWellKnownEqualityComparer(System.Object)
       test      eax,eax
       je        short M03_L08
       mov       ecx,[edi+0C]
       call      System.Collections.HashHelpers.GetRandomizedEqualityComparer(System.Object)
       mov       edx,eax
       mov       ecx,offset MT_System.Collections.Generic.IEqualityComparer`1[[System.UInt64, mscorlib]]
       call      CORINFO_HELP_CHKCASTANY
       lea       edx,[edi+0C]
       call      CORINFO_HELP_ASSIGN_REF_EAX
       mov       esi,[edi+8]
       mov       edx,[esi+4]
       push      1
       mov       ecx,edi
       call      dword ptr ds:[2764C7C]; System.Collections.Generic.Dictionary`2[[System.UInt64, mscorlib],[System.UInt64, mscorlib]].Resize(Int32, Boolean)
M03_L08:
       lea       esp,[ebp-0C]
       pop       ebx
       pop       esi
       pop       edi
       pop       ebp
       ret       10
M03_L09:
       call      CORINFO_HELP_RNGCHKFAIL
       int       3
; Total bytes of code 530
```

## .NET Framework 4.8.1 (4.8.9181.0), X86 LegacyJIT
```assembly
; AsyncExpert_1_Benchmark.FibonacciCalc.Iterative(UInt64)
       push      ebp
       mov       ebp,esp
       push      edi
       push      esi
       push      ebx
       sub       esp,8
       mov       eax,[ebp+8]
       or        eax,[ebp+0C]
       jne       short M00_L00
       xor       eax,eax
       xor       edx,edx
       lea       esp,[ebp-0C]
       pop       ebx
       pop       esi
       pop       edi
       pop       ebp
       ret       8
M00_L00:
       cmp       dword ptr [ebp+0C],0
       jne       short M00_L01
       cmp       dword ptr [ebp+8],1
       jne       short M00_L01
       mov       eax,1
       xor       edx,edx
       lea       esp,[ebp-0C]
       pop       ebx
       pop       esi
       pop       edi
       pop       ebp
       ret       8
M00_L01:
       mov       dword ptr [ebp-14],0
       mov       dword ptr [ebp-10],0
       mov       esi,1
       xor       edi,edi
       lea       ecx,[esi+1]
       xor       ebx,ebx
       cmp       dword ptr [ebp+0C],0
       ja        short M00_L02
       jb        short M00_L03
       cmp       dword ptr [ebp+8],2
       jb        short M00_L03
M00_L02:
       mov       eax,[ebp-14]
       mov       edx,[ebp-10]
       add       eax,esi
       adc       edx,edi
       mov       [ebp-14],esi
       mov       [ebp-10],edi
       mov       esi,eax
       mov       edi,edx
       add       ecx,1
       adc       ebx,0
       cmp       ebx,[ebp+0C]
       ja        short M00_L03
       jb        short M00_L02
       cmp       ecx,[ebp+8]
       jbe       short M00_L02
M00_L03:
       mov       eax,esi
       mov       edx,edi
       lea       esp,[ebp-0C]
       pop       ebx
       pop       esi
       pop       edi
       pop       ebp
       ret       8
; Total bytes of code 152
```

## .NET Framework 4.8.1 (4.8.9181.0), X86 LegacyJIT
```assembly
; AsyncExpert_1_Benchmark.FibonacciCalc.Recursive(UInt64)
M00_L00:
       push      ebp
       mov       ebp,esp
       push      edi
       push      esi
       push      ebx
       mov       esi,ecx
       cmp       dword ptr [ebp+0C],0
       jne       short M00_L01
       cmp       dword ptr [ebp+8],1
       je        short M00_L02
M00_L01:
       cmp       dword ptr [ebp+0C],0
       jne       short M00_L03
       cmp       dword ptr [ebp+8],2
       jne       short M00_L03
M00_L02:
       mov       eax,1
       xor       edx,edx
       pop       ebx
       pop       esi
       pop       edi
       pop       ebp
       ret       8
M00_L03:
       mov       eax,[ebp+8]
       mov       edx,[ebp+0C]
       sub       eax,2
       sbb       edx,0
       push      edx
       push      eax
       mov       ecx,esi
       call      dword ptr ds:[54D4BF0]
       mov       ebx,eax
       mov       edi,edx
       mov       eax,[ebp+8]
       mov       edx,[ebp+0C]
       sub       eax,1
       sbb       edx,0
       push      edx
       push      eax
       mov       ecx,esi
       call      dword ptr ds:[54D4BF0]
       add       eax,ebx
       adc       edx,edi
       pop       ebx
       pop       esi
       pop       edi
       pop       ebp
       ret       8
; Total bytes of code 105
```

## .NET Framework 4.8.1 (4.8.9181.0), X86 LegacyJIT
```assembly
; AsyncExpert_1_Benchmark.FibonacciCalc.RecursiveWithMemoization(UInt64)
M00_L00:
       push      ebp
       mov       ebp,esp
       push      edi
       push      esi
       push      ebx
       sub       esp,10
       mov       esi,ecx
       mov       ebx,[ebp+8]
       mov       edi,[ebp+0C]
       test      edi,edi
       jne       short M00_L01
       cmp       ebx,1
       je        short M00_L02
M00_L01:
       test      edi,edi
       jne       short M00_L03
       cmp       ebx,2
       jne       short M00_L03
M00_L02:
       mov       eax,1
       xor       edx,edx
       lea       esp,[ebp-0C]
       pop       ebx
       pop       esi
       pop       edi
       pop       ebp
       ret       8
M00_L03:
       mov       ecx,[esi+4]
       cmp       [ecx],al
       push      edi
       push      ebx
       call      dword ptr ds:[1594C6C]; System.Collections.Generic.Dictionary`2[[System.UInt64, mscorlib],[System.UInt64, mscorlib]].FindEntry(UInt64)
       test      eax,eax
       jl        short M00_L04
       mov       ecx,[esi+4]
       push      edi
       push      ebx
       cmp       [ecx],ecx
       call      dword ptr ds:[1594BC4]; System.Collections.Generic.Dictionary`2[[System.UInt64, mscorlib],[System.UInt64, mscorlib]].get_Item(UInt64)
       lea       esp,[ebp-0C]
       pop       ebx
       pop       esi
       pop       edi
       pop       ebp
       ret       8
M00_L04:
       mov       eax,ebx
       mov       edx,edi
       sub       eax,1
       sbb       edx,0
       push      edx
       push      eax
       mov       ecx,esi
       call      dword ptr ds:[5784BFC]
       mov       [ebp-1C],eax
       mov       [ebp-18],edx
       mov       eax,ebx
       mov       edx,edi
       sub       eax,2
       sbb       edx,0
       push      edx
       push      eax
       mov       ecx,esi
       call      dword ptr ds:[5784BFC]
       add       eax,[ebp-1C]
       adc       edx,[ebp-18]
       mov       [ebp-14],eax
       mov       [ebp-10],edx
       mov       ecx,[esi+4]
       cmp       [ecx],al
       push      edi
       push      ebx
       push      dword ptr [ebp-10]
       push      dword ptr [ebp-14]
       xor       edx,edx
       call      dword ptr ds:[1594C74]; System.Collections.Generic.Dictionary`2[[System.UInt64, mscorlib],[System.UInt64, mscorlib]].Insert(UInt64, UInt64, Boolean)
       mov       eax,[ebp-14]
       mov       edx,[ebp-10]
       lea       esp,[ebp-0C]
       pop       ebx
       pop       esi
       pop       edi
       pop       ebp
       ret       8
; Total bytes of code 187
```
```assembly
; System.Collections.Generic.Dictionary`2[[System.UInt64, mscorlib],[System.UInt64, mscorlib]].FindEntry(UInt64)
       push      ebp
       mov       ebp,esp
       push      edi
       push      esi
       push      ebx
       push      eax
       mov       edi,ecx
       mov       esi,[edi+4]
       test      esi,esi
       je        near ptr M01_L02
       mov       ecx,[edi+0C]
       push      dword ptr [ebp+0C]
       push      dword ptr [ebp+8]
       call      dword ptr ds:[15C0030]
       and       eax,7FFFFFFF
       mov       [ebp-10],eax
       mov       esi,[edi+4]
       mov       ecx,[esi+4]
       cdq
       idiv      ecx
       cmp       edx,[esi+4]
       jae       short M01_L03
       mov       esi,[esi+edx*4+8]
       test      esi,esi
       jl        short M01_L02
       mov       ecx,[edi+8]
M01_L00:
       cmp       esi,[ecx+4]
       jae       short M01_L03
       lea       eax,[esi+esi*2]
       lea       eax,[ecx+eax*8+8]
       mov       eax,[eax]
       cmp       eax,[ebp-10]
       jne       short M01_L01
       mov       ebx,[edi+0C]
       lea       eax,[esi+esi*2]
       push      dword ptr [ecx+eax*8+14]
       push      dword ptr [ecx+eax*8+10]
       push      dword ptr [ebp+0C]
       push      dword ptr [ebp+8]
       mov       ecx,ebx
       call      dword ptr ds:[15C0034]
       test      eax,eax
       je        short M01_L01
       mov       eax,esi
       pop       ecx
       pop       ebx
       pop       esi
       pop       edi
       pop       ebp
       ret       8
M01_L01:
       mov       ecx,[edi+8]
       cmp       esi,[ecx+4]
       jae       short M01_L03
       lea       eax,[esi+esi*2]
       lea       eax,[ecx+eax*8+8]
       mov       esi,[eax+4]
       test      esi,esi
       jge       short M01_L00
M01_L02:
       or        eax,0FFFFFFFF
       pop       ecx
       pop       ebx
       pop       esi
       pop       edi
       pop       ebp
       ret       8
M01_L03:
       call      CORINFO_HELP_RNGCHKFAIL
       int       3
; Total bytes of code 168
```
```assembly
; System.Collections.Generic.Dictionary`2[[System.UInt64, mscorlib],[System.UInt64, mscorlib]].get_Item(UInt64)
       push      ebp
       mov       ebp,esp
       push      esi
       sub       esp,8
       xor       eax,eax
       mov       [ebp-0C],eax
       mov       [ebp-8],eax
       mov       esi,ecx
       push      dword ptr [ebp+0C]
       push      dword ptr [ebp+8]
       mov       ecx,esi
       call      System.Collections.Generic.Dictionary`2[[System.UInt64, mscorlib],[System.UInt64, mscorlib]].FindEntry(UInt64)
       mov       ecx,eax
       test      ecx,ecx
       jl        short M02_L00
       mov       eax,[esi+8]
       cmp       ecx,[eax+4]
       jae       short M02_L01
       lea       edx,[ecx+ecx*2]
       lea       ecx,[eax+edx*8+8]
       mov       eax,[ecx+10]
       mov       edx,[ecx+14]
       lea       esp,[ebp-4]
       pop       esi
       pop       ebp
       ret       8
M02_L00:
       mov       ecx,offset MT_System.Collections.Generic.KeyNotFoundException
       call      CORINFO_HELP_NEWSFAST
       mov       esi,eax
       mov       ecx,esi
       call      dword ptr ds:[70A54E18]; System.Collections.Generic.KeyNotFoundException..ctor()
       mov       ecx,esi
       call      CORINFO_HELP_THROW
M02_L01:
       call      CORINFO_HELP_RNGCHKFAIL
       int       3
; Total bytes of code 98
```
```assembly
; System.Collections.Generic.Dictionary`2[[System.UInt64, mscorlib],[System.UInt64, mscorlib]].Insert(UInt64, UInt64, Boolean)
       push      ebp
       mov       ebp,esp
       push      edi
       push      esi
       push      ebx
       sub       esp,14
       mov       [ebp-10],edx
       mov       edi,ecx
       mov       ebx,[edi+4]
       test      ebx,ebx
       jne       short M03_L00
       mov       ecx,edi
       xor       edx,edx
       call      dword ptr ds:[1594C70]; System.Collections.Generic.Dictionary`2[[System.UInt64, mscorlib],[System.UInt64, mscorlib]].Initialize(Int32)
M03_L00:
       mov       ecx,[edi+0C]
       push      dword ptr [ebp+14]
       push      dword ptr [ebp+10]
       call      dword ptr ds:[15C0038]
       and       eax,7FFFFFFF
       mov       [ebp-14],eax
       mov       ebx,[edi+4]
       mov       ecx,[ebx+4]
       cdq
       idiv      ecx
       mov       [ebp-18],edx
       xor       edx,edx
       mov       [ebp-1C],edx
       mov       eax,[ebp-18]
       cmp       eax,[ebx+4]
       jae       near ptr M03_L09
       mov       ebx,[ebx+eax*4+8]
       test      ebx,ebx
       jl        near ptr M03_L04
M03_L01:
       mov       esi,[edi+8]
       cmp       ebx,[esi+4]
       jae       near ptr M03_L09
       lea       eax,[ebx+ebx*2]
       lea       eax,[esi+eax*8+8]
       mov       eax,[eax]
       cmp       eax,[ebp-14]
       jne       short M03_L03
       mov       ecx,[edi+0C]
       lea       eax,[ebx+ebx*2]
       push      dword ptr [esi+eax*8+14]
       push      dword ptr [esi+eax*8+10]
       push      dword ptr [ebp+14]
       push      dword ptr [ebp+10]
       call      dword ptr ds:[15C003C]
       test      eax,eax
       je        short M03_L03
       movzx     eax,byte ptr [ebp-10]
       test      eax,eax
       je        short M03_L02
       mov       ecx,0E
       call      System.ThrowHelper.ThrowArgumentException(System.ExceptionResource)
M03_L02:
       mov       esi,[edi+8]
       cmp       ebx,[esi+4]
       jae       near ptr M03_L09
       lea       eax,[ebx+ebx*2]
       lea       eax,[esi+eax*8+8]
       mov       ecx,[ebp+8]
       mov       edx,[ebp+0C]
       mov       [eax+10],ecx
       mov       [eax+14],edx
       inc       dword ptr [edi+20]
       lea       esp,[ebp-0C]
       pop       ebx
       pop       esi
       pop       edi
       pop       ebp
       ret       10
M03_L03:
       inc       dword ptr [ebp-1C]
       mov       esi,[edi+8]
       cmp       ebx,[esi+4]
       jae       near ptr M03_L09
       lea       eax,[ebx+ebx*2]
       lea       eax,[esi+eax*8+8]
       mov       ebx,[eax+4]
       test      ebx,ebx
       jge       near ptr M03_L01
M03_L04:
       cmp       dword ptr [edi+28],0
       jle       short M03_L05
       mov       eax,[edi+24]
       mov       [ebp-20],eax
       mov       esi,[edi+8]
       cmp       eax,[esi+4]
       jae       near ptr M03_L09
       lea       edx,[eax+eax*2]
       lea       edx,[esi+edx*8+8]
       mov       eax,[edx+4]
       mov       [edi+24],eax
       dec       dword ptr [edi+28]
       jmp       short M03_L07
M03_L05:
       mov       eax,[edi+1C]
       mov       esi,[edi+8]
       cmp       eax,[esi+4]
       jne       short M03_L06
       mov       ecx,[edi+1C]
       call      System.Collections.HashHelpers.ExpandPrime(Int32)
       mov       edx,eax
       push      0
       mov       ecx,edi
       call      dword ptr ds:[1594C7C]; System.Collections.Generic.Dictionary`2[[System.UInt64, mscorlib],[System.UInt64, mscorlib]].Resize(Int32, Boolean)
       mov       eax,[ebp-14]
       mov       ebx,[edi+4]
       mov       ecx,[ebx+4]
       cdq
       idiv      ecx
       mov       [ebp-18],edx
M03_L06:
       mov       eax,[edi+1C]
       mov       [ebp-20],eax
       inc       dword ptr [edi+1C]
M03_L07:
       mov       eax,[ebp-20]
       mov       esi,[edi+8]
       cmp       eax,[esi+4]
       jae       near ptr M03_L09
       lea       edx,[eax+eax*2]
       lea       edx,[esi+edx*8+8]
       mov       eax,[ebp-14]
       mov       [edx],eax
       mov       eax,[ebp-20]
       lea       eax,[eax+eax*2]
       mov       edx,[ebp-18]
       mov       ebx,[edi+4]
       cmp       edx,[ebx+4]
       jae       near ptr M03_L09
       mov       edx,[ebx+edx*4+8]
       mov       [esi+eax*8+0C],edx
       mov       eax,[ebp-20]
       lea       eax,[eax+eax*2]
       mov       ecx,[ebp+10]
       mov       edx,[ebp+14]
       mov       [esi+eax*8+10],ecx
       mov       [esi+eax*8+14],edx
       mov       eax,[ebp-20]
       lea       eax,[eax+eax*2]
       mov       ecx,[ebp+8]
       mov       edx,[ebp+0C]
       mov       [esi+eax*8+18],ecx
       mov       [esi+eax*8+1C],edx
       mov       eax,[ebp-18]
       mov       edx,[ebp-20]
       mov       [ebx+eax*4+8],edx
       inc       dword ptr [edi+20]
       cmp       dword ptr [ebp-1C],64
       jle       short M03_L08
       mov       ecx,[edi+0C]
       call      System.Collections.HashHelpers.IsWellKnownEqualityComparer(System.Object)
       test      eax,eax
       je        short M03_L08
       mov       ecx,[edi+0C]
       call      System.Collections.HashHelpers.GetRandomizedEqualityComparer(System.Object)
       mov       edx,eax
       mov       ecx,offset MT_System.Collections.Generic.IEqualityComparer`1[[System.UInt64, mscorlib]]
       call      CORINFO_HELP_CHKCASTANY
       lea       edx,[edi+0C]
       call      CORINFO_HELP_ASSIGN_REF_EAX
       mov       esi,[edi+8]
       mov       edx,[esi+4]
       push      1
       mov       ecx,edi
       call      dword ptr ds:[1594C7C]; System.Collections.Generic.Dictionary`2[[System.UInt64, mscorlib],[System.UInt64, mscorlib]].Resize(Int32, Boolean)
M03_L08:
       lea       esp,[ebp-0C]
       pop       ebx
       pop       esi
       pop       edi
       pop       ebp
       ret       10
M03_L09:
       call      CORINFO_HELP_RNGCHKFAIL
       int       3
; Total bytes of code 530
```

## .NET Framework 4.8.1 (4.8.9181.0), X86 LegacyJIT
```assembly
; AsyncExpert_1_Benchmark.FibonacciCalc.Iterative(UInt64)
       push      ebp
       mov       ebp,esp
       push      edi
       push      esi
       push      ebx
       sub       esp,8
       mov       eax,[ebp+8]
       or        eax,[ebp+0C]
       jne       short M00_L00
       xor       eax,eax
       xor       edx,edx
       lea       esp,[ebp-0C]
       pop       ebx
       pop       esi
       pop       edi
       pop       ebp
       ret       8
M00_L00:
       cmp       dword ptr [ebp+0C],0
       jne       short M00_L01
       cmp       dword ptr [ebp+8],1
       jne       short M00_L01
       mov       eax,1
       xor       edx,edx
       lea       esp,[ebp-0C]
       pop       ebx
       pop       esi
       pop       edi
       pop       ebp
       ret       8
M00_L01:
       mov       dword ptr [ebp-14],0
       mov       dword ptr [ebp-10],0
       mov       esi,1
       xor       edi,edi
       lea       ecx,[esi+1]
       xor       ebx,ebx
       cmp       dword ptr [ebp+0C],0
       ja        short M00_L02
       jb        short M00_L03
       cmp       dword ptr [ebp+8],2
       jb        short M00_L03
M00_L02:
       mov       eax,[ebp-14]
       mov       edx,[ebp-10]
       add       eax,esi
       adc       edx,edi
       mov       [ebp-14],esi
       mov       [ebp-10],edi
       mov       esi,eax
       mov       edi,edx
       add       ecx,1
       adc       ebx,0
       cmp       ebx,[ebp+0C]
       ja        short M00_L03
       jb        short M00_L02
       cmp       ecx,[ebp+8]
       jbe       short M00_L02
M00_L03:
       mov       eax,esi
       mov       edx,edi
       lea       esp,[ebp-0C]
       pop       ebx
       pop       esi
       pop       edi
       pop       ebp
       ret       8
; Total bytes of code 152
```

