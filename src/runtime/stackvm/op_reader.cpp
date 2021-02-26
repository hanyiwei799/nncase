/* This file is generated by tools/stackvm_gen/IsaGen at 2021/2/23 16:24:09 +08:00.
 *
 * Copyright 2020 Canaan Inc.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *     http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */
#pragma once
#include <nncase/runtime/stackvm/op_reader.h>

using namespace nncase;
using namespace nncase::runtime;
using namespace nncase::runtime::stackvm;

result<void> op_visitor::next() noexcept
{
    auto opcode = static_cast<opcode_t>(reader_.peek_unaligned<uint8_t>());
    if (opcode == opcode_t::TENSOR)
    {
        auto tensor_funct = static_cast<tensor_function_t>(reader_.peek_unaligned_with_offset<uint16_t>(1));
        switch (tensor_funct)
        {
        case tensor_function_t::BATCH_TO_SPACE:
            return visit(op_reader<tensor_batch_to_space_op_t>()(reader_));
        case tensor_function_t::BROADCAST:
            return visit(op_reader<tensor_broadcast_op_t>()(reader_));
        case tensor_function_t::BINARY:
            return visit(op_reader<tensor_binary_op_t>()(reader_));
        case tensor_function_t::CALL:
            return visit(op_reader<tensor_call_op_t>()(reader_));
        case tensor_function_t::CONCAT:
            return visit(op_reader<tensor_concat_op_t>()(reader_));
        case tensor_function_t::CONV2D:
            return visit(op_reader<tensor_conv2d_op_t>()(reader_));
        case tensor_function_t::DEQUANTIZE:
            return visit(op_reader<tensor_dequantize_op_t>()(reader_));
        case tensor_function_t::QUANTIZE:
            return visit(op_reader<tensor_quantize_op_t>()(reader_));
        case tensor_function_t::REDUCE:
            return visit(op_reader<tensor_reduce_op_t>()(reader_));
        case tensor_function_t::UNARY:
            return visit(op_reader<tensor_unary_op_t>()(reader_));
        case tensor_function_t::TRANSPOSE:
            return visit(op_reader<tensor_transpose_op_t>()(reader_));
        default:
            break;
        }
    }
    else
    {
        switch (opcode)
        {
        case opcode_t::NOP:
            return visit(op_reader<nop_op_t>()(reader_));
        case opcode_t::BR:
            return visit(op_reader<br_op_t>()(reader_));
        case opcode_t::BR_TRUE:
            return visit(op_reader<br_true_op_t>()(reader_));
        case opcode_t::BR_FALSE:
            return visit(op_reader<br_false_op_t>()(reader_));
        case opcode_t::RET:
            return visit(op_reader<ret_op_t>()(reader_));
        case opcode_t::CALL:
            return visit(op_reader<call_op_t>()(reader_));
        case opcode_t::ECALL:
            return visit(op_reader<ecall_op_t>()(reader_));
        case opcode_t::THROW:
            return visit(op_reader<throw_op_t>()(reader_));
        case opcode_t::BREAK:
            return visit(op_reader<break_op_t>()(reader_));
        case opcode_t::LDC_I4:
            return visit(op_reader<ldc_i4_op_t>()(reader_));
        case opcode_t::LDNULL:
            return visit(op_reader<ldnull_op_t>()(reader_));
        case opcode_t::LDC_I4_0:
            return visit(op_reader<ldc_i4_0_op_t>()(reader_));
        case opcode_t::LDC_I4_1:
            return visit(op_reader<ldc_i4_1_op_t>()(reader_));
        case opcode_t::LDC_R4:
            return visit(op_reader<ldc_r4_op_t>()(reader_));
        case opcode_t::LDIND_I1:
            return visit(op_reader<ldind_i1_op_t>()(reader_));
        case opcode_t::LDIND_I2:
            return visit(op_reader<ldind_i2_op_t>()(reader_));
        case opcode_t::LDIND_I4:
            return visit(op_reader<ldind_i4_op_t>()(reader_));
        case opcode_t::LDIND_I:
            return visit(op_reader<ldind_i_op_t>()(reader_));
        case opcode_t::LDIND_U1:
            return visit(op_reader<ldind_u1_op_t>()(reader_));
        case opcode_t::LDIND_U2:
            return visit(op_reader<ldind_u2_op_t>()(reader_));
        case opcode_t::LDIND_U4:
            return visit(op_reader<ldind_u4_op_t>()(reader_));
        case opcode_t::LDIND_U:
            return visit(op_reader<ldind_u_op_t>()(reader_));
        case opcode_t::LDIND_BR2:
            return visit(op_reader<ldind_br2_op_t>()(reader_));
        case opcode_t::LDIND_R4:
            return visit(op_reader<ldind_r4_op_t>()(reader_));
        case opcode_t::STIND_I1:
            return visit(op_reader<stind_i1_op_t>()(reader_));
        case opcode_t::STIND_I2:
            return visit(op_reader<stind_i2_op_t>()(reader_));
        case opcode_t::STIND_I4:
            return visit(op_reader<stind_i4_op_t>()(reader_));
        case opcode_t::STIND_I:
            return visit(op_reader<stind_i_op_t>()(reader_));
        case opcode_t::STIND_BR2:
            return visit(op_reader<stind_br2_op_t>()(reader_));
        case opcode_t::STIND_R4:
            return visit(op_reader<stind_r4_op_t>()(reader_));
        case opcode_t::LEA_GP:
            return visit(op_reader<lea_gp_op_t>()(reader_));
        case opcode_t::LEA_BUFFER:
            return visit(op_reader<lea_buffer_op_t>()(reader_));
        case opcode_t::LDELEM_I1:
            return visit(op_reader<ldelem_i1_op_t>()(reader_));
        case opcode_t::LDELEM_I2:
            return visit(op_reader<ldelem_i2_op_t>()(reader_));
        case opcode_t::LDELEM_I4:
            return visit(op_reader<ldelem_i4_op_t>()(reader_));
        case opcode_t::LDELEM_I:
            return visit(op_reader<ldelem_i_op_t>()(reader_));
        case opcode_t::LDELEM_U1:
            return visit(op_reader<ldelem_u1_op_t>()(reader_));
        case opcode_t::LDELEM_U2:
            return visit(op_reader<ldelem_u2_op_t>()(reader_));
        case opcode_t::LDELEM_U4:
            return visit(op_reader<ldelem_u4_op_t>()(reader_));
        case opcode_t::LDELEM_U:
            return visit(op_reader<ldelem_u_op_t>()(reader_));
        case opcode_t::LDELEM_BR2:
            return visit(op_reader<ldelem_br2_op_t>()(reader_));
        case opcode_t::LDELEM_R4:
            return visit(op_reader<ldelem_r4_op_t>()(reader_));
        case opcode_t::STELEM_I1:
            return visit(op_reader<stelem_i1_op_t>()(reader_));
        case opcode_t::STELEM_I2:
            return visit(op_reader<stelem_i2_op_t>()(reader_));
        case opcode_t::STELEM_I4:
            return visit(op_reader<stelem_i4_op_t>()(reader_));
        case opcode_t::STELEM_I:
            return visit(op_reader<stelem_i_op_t>()(reader_));
        case opcode_t::STELEM_BR2:
            return visit(op_reader<stelem_br2_op_t>()(reader_));
        case opcode_t::STELEM_R4:
            return visit(op_reader<stelem_r4_op_t>()(reader_));
        case opcode_t::LDARG:
            return visit(op_reader<ldarg_op_t>()(reader_));
        case opcode_t::LDARG_0:
            return visit(op_reader<ldarg_0_op_t>()(reader_));
        case opcode_t::LDARG_1:
            return visit(op_reader<ldarg_1_op_t>()(reader_));
        case opcode_t::LDARG_2:
            return visit(op_reader<ldarg_2_op_t>()(reader_));
        case opcode_t::LDARG_3:
            return visit(op_reader<ldarg_3_op_t>()(reader_));
        case opcode_t::LDARG_4:
            return visit(op_reader<ldarg_4_op_t>()(reader_));
        case opcode_t::LDARG_5:
            return visit(op_reader<ldarg_5_op_t>()(reader_));
        case opcode_t::STSHAPE:
            return visit(op_reader<stshape_op_t>()(reader_));
        case opcode_t::STPADDINGS:
            return visit(op_reader<stpaddings_op_t>()(reader_));
        case opcode_t::DUP:
            return visit(op_reader<dup_op_t>()(reader_));
        case opcode_t::POP:
            return visit(op_reader<pop_op_t>()(reader_));
        case opcode_t::NEG:
            return visit(op_reader<neg_op_t>()(reader_));
        case opcode_t::ADD:
            return visit(op_reader<add_op_t>()(reader_));
        case opcode_t::SUB:
            return visit(op_reader<sub_op_t>()(reader_));
        case opcode_t::MUL:
            return visit(op_reader<mul_op_t>()(reader_));
        case opcode_t::DIV:
            return visit(op_reader<div_op_t>()(reader_));
        case opcode_t::DIV_U:
            return visit(op_reader<div_u_op_t>()(reader_));
        case opcode_t::REM:
            return visit(op_reader<rem_op_t>()(reader_));
        case opcode_t::REM_U:
            return visit(op_reader<rem_u_op_t>()(reader_));
        case opcode_t::AND:
            return visit(op_reader<and_op_t>()(reader_));
        case opcode_t::OR:
            return visit(op_reader<or_op_t>()(reader_));
        case opcode_t::XOR:
            return visit(op_reader<xor_op_t>()(reader_));
        case opcode_t::NOT:
            return visit(op_reader<not_op_t>()(reader_));
        case opcode_t::SHL:
            return visit(op_reader<shl_op_t>()(reader_));
        case opcode_t::SHR:
            return visit(op_reader<shr_op_t>()(reader_));
        case opcode_t::SHR_U:
            return visit(op_reader<shr_u_op_t>()(reader_));
        case opcode_t::CLT:
            return visit(op_reader<clt_op_t>()(reader_));
        case opcode_t::CLT_U:
            return visit(op_reader<clt_u_op_t>()(reader_));
        case opcode_t::CLE:
            return visit(op_reader<cle_op_t>()(reader_));
        case opcode_t::CLE_U:
            return visit(op_reader<cle_u_op_t>()(reader_));
        case opcode_t::CEQ:
            return visit(op_reader<ceq_op_t>()(reader_));
        case opcode_t::CGE:
            return visit(op_reader<cge_op_t>()(reader_));
        case opcode_t::CGE_U:
            return visit(op_reader<cge_u_op_t>()(reader_));
        case opcode_t::CGT:
            return visit(op_reader<cgt_op_t>()(reader_));
        case opcode_t::CGT_U:
            return visit(op_reader<cgt_u_op_t>()(reader_));
        case opcode_t::CNE:
            return visit(op_reader<cne_op_t>()(reader_));
        case opcode_t::CONV_I1:
            return visit(op_reader<conv_i1_op_t>()(reader_));
        case opcode_t::CONV_I2:
            return visit(op_reader<conv_i2_op_t>()(reader_));
        case opcode_t::CONV_I4:
            return visit(op_reader<conv_i4_op_t>()(reader_));
        case opcode_t::CONV_I:
            return visit(op_reader<conv_i_op_t>()(reader_));
        case opcode_t::CONV_U1:
            return visit(op_reader<conv_u1_op_t>()(reader_));
        case opcode_t::CONV_U2:
            return visit(op_reader<conv_u2_op_t>()(reader_));
        case opcode_t::CONV_U4:
            return visit(op_reader<conv_u4_op_t>()(reader_));
        case opcode_t::CONV_U:
            return visit(op_reader<conv_u_op_t>()(reader_));
        case opcode_t::CONV_BR2:
            return visit(op_reader<conv_br2_op_t>()(reader_));
        case opcode_t::CONV_R4:
            return visit(op_reader<conv_r4_op_t>()(reader_));
        default:
            break;
        }
    }

    return err(nncase_errc::stackvm_illegal_instruction);
}

result<void> op_visitor::visit(gsl::span<const gsl::byte> text) noexcept
{
    reader_ = span_reader(text);
    interrupted_ = false;

    while (!interrupted_ && !reader_.empty())
        try_(next());
    return ok();
}
