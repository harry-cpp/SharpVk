// The MIT License (MIT)
// 
// Copyright (c) Andrew Armstrong/FacticiusVir 2020
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in all
// copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
// SOFTWARE.

// This file was automatically generated and should not be edited directly.

using System;
using System.Runtime.InteropServices;

namespace SharpVk
{
    /// <summary>
    /// 
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public partial struct BindImageMemoryDeviceGroupInfo
    {
        /// <summary>
        /// 
        /// </summary>
        public uint[] DeviceIndices
        {
            get;
            set;
        }
        
        /// <summary>
        /// 
        /// </summary>
        public SharpVk.Rect2D[] SplitInstanceBindRegions
        {
            get;
            set;
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pointer">
        /// </param>
        internal unsafe void MarshalTo(SharpVk.Interop.BindImageMemoryDeviceGroupInfo* pointer)
        {
            pointer->SType = StructureType.BindImageMemoryDeviceGroupInfoVersion;
            pointer->Next = null;
            pointer->DeviceIndexCount = (uint)(Interop.HeapUtil.GetLength(this.DeviceIndices));
            if (this.DeviceIndices != null)
            {
                var fieldPointer = (uint*)(Interop.HeapUtil.AllocateAndClear<uint>(this.DeviceIndices.Length).ToPointer());
                for(int index = 0; index < (uint)(this.DeviceIndices.Length); index++)
                {
                    fieldPointer[index] = this.DeviceIndices[index];
                }
                pointer->DeviceIndices = fieldPointer;
            }
            else
            {
                pointer->DeviceIndices = null;
            }
            pointer->SplitInstanceBindRegionCount = (uint)(Interop.HeapUtil.GetLength(this.SplitInstanceBindRegions));
            if (this.SplitInstanceBindRegions != null)
            {
                var fieldPointer = (SharpVk.Rect2D*)(Interop.HeapUtil.AllocateAndClear<SharpVk.Rect2D>(this.SplitInstanceBindRegions.Length).ToPointer());
                for(int index = 0; index < (uint)(this.SplitInstanceBindRegions.Length); index++)
                {
                    fieldPointer[index] = this.SplitInstanceBindRegions[index];
                }
                pointer->SplitInstanceBindRegions = fieldPointer;
            }
            else
            {
                pointer->SplitInstanceBindRegions = null;
            }
        }
    }
}
