﻿using Remotion.Linq.Parsing.Structure;
using SharpVk.Spirv;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpVk.Shanq
{
    public static class ShanqShader<TInput>
    {
        public static void CreateFragment<TOutput>(Stream outputStream, Func<IQueryable<TInput>, IQueryable<TOutput>> shaderFunction)
        {
            var queryable = new ShanqQueryable<TInput>(QueryParser.CreateDefault(), new ShanqQueryExecutor(ExecutionModel.Fragment, outputStream));

            shaderFunction(queryable).ToArray();
        }

        public static void Create<TOutput>(ExecutionModel model, Stream outputStream, Func<IQueryable<TInput>, IQueryable<TOutput>> shaderFunction)
        {
            var queryable = new ShanqQueryable<TInput>(QueryParser.CreateDefault(), new ShanqQueryExecutor(model, outputStream));

            shaderFunction(queryable).ToArray();
        }

        public static ShaderModule CreateFragmentModule<TOutput>(Device device, Func<IQueryable<TInput>, IQueryable<TOutput>> shaderFunction)
        {
            var fragShaderStream = new MemoryStream();

            CreateFragment(fragShaderStream, shaderFunction);

            int fragShaderLength = (int)fragShaderStream.Length;

            var fragShaderBytes = fragShaderStream.GetBuffer();

            var fragShaderData = LoadShaderData(fragShaderBytes, fragShaderLength);

            return device.CreateShaderModule(new ShaderModuleCreateInfo
            {
                Code = fragShaderData,
                CodeSize = (UIntPtr)fragShaderLength
            });
        }

        private static uint[] LoadShaderData(byte[] shaderBytes, int codeSize)
        {
            var shaderData = new uint[(int)Math.Ceiling(codeSize / 4f)];

            System.Buffer.BlockCopy(shaderBytes, 0, shaderData, 0, codeSize);

            return shaderData;
        }
    }
}
