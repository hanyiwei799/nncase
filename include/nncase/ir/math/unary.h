/* Copyright 2019-2021 Canaan Inc.
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
#include "../call.h"
#include "../op.h"
#include "nncase/runtime/datatypes.h"
#include "opcode.h"

namespace nncase::ir::math {
/** @brief Unary operator node */
class NNCASE_API unary_node : public op_node {
    DEFINE_OBJECT_KIND(op_node, op_math_unary)
  public:
    unary_node(unary_op_t unary_op);

    /** @brief Get the unary opcode of the unary expression */
    unary_op_t unary_op() const noexcept { return unary_op_; }
    /** @brief Set the unary opcode of the unary expression */
    void unary_op(unary_op_t value) noexcept { unary_op_ = value; }

    /** @brief Get the input the unary expression */
    const connector_info &input() const noexcept { return parameter_at(0); }

    type infer_invoke_result_type(type_infer_context &context) override;

  private:
    unary_op_t unary_op_;
};

/** @brief Unary expression */
class unary : public object_t<unary_node> {
  public:
    using object_t::object_t;

    /** @brief Construct an unary expression
     *  @param[in] unary_op The opcode of the unary
     */
    NNCASE_API unary(unary_op_t unary_op);
};
} // namespace nncase::ir::math