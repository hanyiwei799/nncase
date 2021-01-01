/* Copyright 2020 Canaan Inc.
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
#include "../tflite_importer.h"
#include <nncase/ir/ops/bitcast.h>

using namespace nncase;
using namespace nncase::importer;
using namespace nncase::ir;

DEFINE_TFLITE_LOWER(RESHAPE)
{
    auto &input = get_tensor(op.inputs(), 0);
    [[maybe_unused]] auto &options = *op.builtin_options_as_ReshapeOptions();
    auto new_shape = load_axis<int32_t>(get_tensor(op.inputs(), 1));

    auto node = graph_.emplace<bitcast>(to_data_type(input.type()), get_shape(input.shape()), to_data_type(input.type()), new_shape);
    node->name(get_tensor(op.outputs(), 0).name()->string_view());

    link_input_tensor(&node->input(), op.inputs()->Get(0));
    link_output_tensor(op.outputs()->Get(0), &node->output());
}
