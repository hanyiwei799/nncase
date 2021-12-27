using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nncase.Pattern.Math;
using Nncase.Pattern.NN;
using Nncase.Pattern.Tensors;
using Nncase.IR;
using Nncase.IR.Math;
using Nncase.IR.NN;
using Nncase.IR.Tensors;

namespace Nncase.Pattern.F
{
    public static partial class Math
    {
        /// <summary>
        /// CallPattern unary.
        /// </summary>
        /// <param name = "unaryOp">Unary operator.</param>
        /// <param name = "expr">Source expression.</param>
        /// <returns>Result expression.</returns>
        public static UnaryWrapper Unary(UnaryOp unaryOp, ExprPattern expr)
        {
            return new UnaryWrapper(new CallPattern(new UnaryPattern(unaryOp), expr));
        }

        /// <summary>
        /// CallPattern binary.
        /// </summary>
        /// <param name = "binaryOp">Binary operator.</param>
        /// <param name = "lhs">Left operand.</param>
        /// <param name = "rhs">Right operand.</param>
        /// <returns>Result expression.</returns>
        public static BinaryWrapper Binary(BinaryOp binaryOp, ExprPattern lhs, ExprPattern rhs)
        {
            return new BinaryWrapper(new CallPattern(new BinaryPattern(binaryOp), lhs, rhs));
        }

        /// <summary>
        /// CallPattern clamp.
        /// </summary>
        /// <param name = "input">Input expression.</param>
        /// <param name = "min">Left operand.</param>
        /// <param name = "max">Right operand.</param>
        /// <returns>Result expression.</returns>
        public static ClampWrapper Clamp(ExprPattern input, ExprPattern min, ExprPattern max)
        {
            return new ClampWrapper(new CallPattern(new ClampPattern(), input, min, max));
        }

        /// <summary>
        /// CallPattern clamp.
        /// </summary>
        /// <param name = "input">Input expression.</param>
        /// <param name = "range">Value range.</param>
        /// <typeparam name = "T">Data type.</typeparam>
        /// <returns>Result expression.</returns>
        public static ClampWrapper Clamp<T>(ExprPattern input, ValueRange<T> range)
            where T : unmanaged
        {
            return new ClampWrapper(new CallPattern(new ClampPattern(), input, Const.FromScalar(range.Min), Const.FromScalar(range.Max)));
        }

        /// <summary>
        /// CallPattern abs.
        /// </summary>
        /// <param name = "expr">Source expression.</param>
        /// <returns>Result expression.</returns>
        public static UnaryWrapper Abs(ExprPattern expr) => Unary(UnaryOp.Abs, expr);
        /// <summary>
        /// CallPattern ceil.
        /// </summary>
        /// <param name = "expr">Source expression.</param>
        /// <returns>Result expression.</returns>
        public static UnaryWrapper Ceil(ExprPattern expr) => Unary(UnaryOp.Ceil, expr);
        /// <summary>
        /// CallPattern cos.
        /// </summary>
        /// <param name = "expr">Source expression.</param>
        /// <returns>Result expression.</returns>
        public static UnaryWrapper Cos(ExprPattern expr) => Unary(UnaryOp.Cos, expr);
        /// <summary>
        /// CallPattern exp.
        /// </summary>
        /// <param name = "expr">Source expression.</param>
        /// <returns>Result expression.</returns>
        public static UnaryWrapper Exp(ExprPattern expr) => Unary(UnaryOp.Exp, expr);
        /// <summary>
        /// CallPattern floor.
        /// </summary>
        /// <param name = "expr">Source expression.</param>
        /// <returns>Result expression.</returns>
        public static UnaryWrapper Floor(ExprPattern expr) => Unary(UnaryOp.Floor, expr);
        /// <summary>
        /// CallPattern log.
        /// </summary>
        /// <param name = "expr">Source expression.</param>
        /// <returns>Result expression.</returns>
        public static UnaryWrapper Log(ExprPattern expr) => Unary(UnaryOp.Log, expr);
        /// <summary>
        /// CallPattern neg.
        /// </summary>
        /// <param name = "expr">Source expression.</param>
        /// <returns>Result expression.</returns>
        public static UnaryWrapper Neg(ExprPattern expr) => Unary(UnaryOp.Neg, expr);
        /// <summary>
        /// CallPattern round.
        /// </summary>
        /// <param name = "expr">Source expression.</param>
        /// <returns>Result expression.</returns>
        public static UnaryWrapper Round(ExprPattern expr) => Unary(UnaryOp.Round, expr);
        /// <summary>
        /// CallPattern rsqrt.
        /// </summary>
        /// <param name = "expr">Source expression.</param>
        /// <returns>Result expression.</returns>
        public static UnaryWrapper Rsqrt(ExprPattern expr) => Unary(UnaryOp.Rsqrt, expr);
        /// <summary>
        /// CallPattern sin.
        /// </summary>
        /// <param name = "expr">Source expression.</param>
        /// <returns>Result expression.</returns>
        public static UnaryWrapper Sin(ExprPattern expr) => Unary(UnaryOp.Sin, expr);
        /// <summary>
        /// CallPattern sqrt.
        /// </summary>
        /// <param name = "expr">Source expression.</param>
        /// <returns>Result expression.</returns>
        public static UnaryWrapper Sqrt(ExprPattern expr) => Unary(UnaryOp.Sqrt, expr);
        /// <summary>
        /// CallPattern square.
        /// </summary>
        /// <param name = "expr">Source expression.</param>
        /// <returns>Result expression.</returns>
        public static UnaryWrapper Square(ExprPattern expr) => Unary(UnaryOp.Square, expr);
        /// <summary>
        /// CallPattern tanh.
        /// </summary>
        /// <param name = "expr">Source expression.</param>
        /// <returns>Result expression.</returns>
        public static UnaryWrapper Tanh(ExprPattern expr) => Unary(UnaryOp.Tanh, expr);
        /// <summary>
        /// CallPattern bitwise not.
        /// </summary>
        /// <param name = "expr">Source expression.</param>
        /// <returns>Result expression.</returns>
        public static UnaryWrapper BitwiseNot(ExprPattern expr) => Unary(UnaryOp.BitwiseNot, expr);
        /// <summary>
        /// CallPattern logical not.
        /// </summary>
        /// <param name = "expr">Source expression.</param>
        /// <returns>Result expression.</returns>
        public static UnaryWrapper LogicalNot(ExprPattern expr) => Unary(UnaryOp.LogicalNot, expr);
        /// <summary>
        /// CallPattern add.
        /// </summary>
        /// <param name = "lhs">Left operand.</param>
        /// <param name = "rhs">Right operand.</param>
        /// <returns>Result expression.</returns>
        public static BinaryWrapper Add(ExprPattern lhs, ExprPattern rhs) => Binary(BinaryOp.Add, lhs, rhs);
        /// <summary>
        /// CallPattern sub.
        /// </summary>
        /// <param name = "lhs">Left operand.</param>
        /// <param name = "rhs">Right operand.</param>
        /// <returns>Result expression.</returns>
        public static BinaryWrapper Sub(ExprPattern lhs, ExprPattern rhs) => Binary(BinaryOp.Sub, lhs, rhs);
        /// <summary>
        /// CallPattern mul.
        /// </summary>
        /// <param name = "lhs">Left operand.</param>
        /// <param name = "rhs">Right operand.</param>
        /// <returns>Result expression.</returns>
        public static BinaryWrapper Mul(ExprPattern lhs, ExprPattern rhs) => Binary(BinaryOp.Mul, lhs, rhs);
        /// <summary>
        /// CallPattern div.
        /// </summary>
        /// <param name = "lhs">Left operand.</param>
        /// <param name = "rhs">Right operand.</param>
        /// <returns>Result expression.</returns>
        public static BinaryWrapper Div(ExprPattern lhs, ExprPattern rhs) => Binary(BinaryOp.Div, lhs, rhs);
        /// <summary>
        /// CallPattern mod.
        /// </summary>
        /// <param name = "lhs">Left operand.</param>
        /// <param name = "rhs">Right operand.</param>
        /// <returns>Result expression.</returns>
        public static BinaryWrapper Mod(ExprPattern lhs, ExprPattern rhs) => Binary(BinaryOp.Mod, lhs, rhs);
        /// <summary>
        /// CallPattern min.
        /// </summary>
        /// <param name = "lhs">Left operand.</param>
        /// <param name = "rhs">Right operand.</param>
        /// <returns>Result expression.</returns>
        public static BinaryWrapper Min(ExprPattern lhs, ExprPattern rhs) => Binary(BinaryOp.Min, lhs, rhs);
        /// <summary>
        /// CallPattern max.
        /// </summary>
        /// <param name = "lhs">Left operand.</param>
        /// <param name = "rhs">Right operand.</param>
        /// <returns>Result expression.</returns>
        public static BinaryWrapper Max(ExprPattern lhs, ExprPattern rhs) => Binary(BinaryOp.Max, lhs, rhs);
        /// <summary>
        /// CallPattern pow.
        /// </summary>
        /// <param name = "lhs">Left operand.</param>
        /// <param name = "rhs">Right operand.</param>
        /// <returns>Result expression.</returns>
        public static BinaryWrapper Pow(ExprPattern lhs, ExprPattern rhs) => Binary(BinaryOp.Pow, lhs, rhs);
        /// <summary>
        /// CallPattern bitwise and.
        /// </summary>
        /// <param name = "lhs">Left operand.</param>
        /// <param name = "rhs">Right operand.</param>
        /// <returns>Result expression.</returns>
        public static BinaryWrapper BitwiseAnd(ExprPattern lhs, ExprPattern rhs) => Binary(BinaryOp.BitwiseAnd, lhs, rhs);
        /// <summary>
        /// CallPattern bitwise or.
        /// </summary>
        /// <param name = "lhs">Left operand.</param>
        /// <param name = "rhs">Right operand.</param>
        /// <returns>Result expression.</returns>
        public static BinaryWrapper BitwiseOr(ExprPattern lhs, ExprPattern rhs) => Binary(BinaryOp.BitwiseOr, lhs, rhs);
        /// <summary>
        /// CallPattern bitwise xor.
        /// </summary>
        /// <param name = "lhs">Left operand.</param>
        /// <param name = "rhs">Right operand.</param>
        /// <returns>Result expression.</returns>
        public static BinaryWrapper BitwiseXor(ExprPattern lhs, ExprPattern rhs) => Binary(BinaryOp.BitwiseXor, lhs, rhs);
        /// <summary>
        /// CallPattern logical and.
        /// </summary>
        /// <param name = "lhs">Left operand.</param>
        /// <param name = "rhs">Right operand.</param>
        /// <returns>Result expression.</returns>
        public static BinaryWrapper LogicalAnd(ExprPattern lhs, ExprPattern rhs) => Binary(BinaryOp.LogicalAnd, lhs, rhs);
        /// <summary>
        /// CallPattern logical or.
        /// </summary>
        /// <param name = "lhs">Left operand.</param>
        /// <param name = "rhs">Right operand.</param>
        /// <returns>Result expression.</returns>
        public static BinaryWrapper LogicalOr(ExprPattern lhs, ExprPattern rhs) => Binary(BinaryOp.LogicalOr, lhs, rhs);
        /// <summary>
        /// CallPattern logical xor.
        /// </summary>
        /// <param name = "lhs">Left operand.</param>
        /// <param name = "rhs">Right operand.</param>
        /// <returns>Result expression.</returns>
        public static BinaryWrapper LogicalXor(ExprPattern lhs, ExprPattern rhs) => Binary(BinaryOp.LogicalXor, lhs, rhs);
        /// <summary>
        /// CallPattern left shift.
        /// </summary>
        /// <param name = "lhs">Left operand.</param>
        /// <param name = "rhs">Right operand.</param>
        /// <returns>Result expression.</returns>
        public static BinaryWrapper LeftShift(ExprPattern lhs, ExprPattern rhs) => Binary(BinaryOp.LeftShift, lhs, rhs);
        /// <summary>
        /// CallPattern right shift.
        /// </summary>
        /// <param name = "lhs">Left operand.</param>
        /// <param name = "rhs">Right operand.</param>
        /// <returns>Result expression.</returns>
        public static BinaryWrapper RightShift(ExprPattern lhs, ExprPattern rhs) => Binary(BinaryOp.RightShift, lhs, rhs);
        /// <summary>
        /// CallPattern floor div.
        /// </summary>
        /// <param name = "lhs">Left operand.</param>
        /// <param name = "rhs">Right operand.</param>
        /// <returns>Result expression.</returns>
        public static UnaryWrapper FloorDiv(ExprPattern lhs, ExprPattern rhs) => Floor(lhs / rhs);
        /// <summary>
        /// CallPattern floor mod.
        /// </summary>
        /// <param name = "lhs">Left operand.</param>
        /// <param name = "rhs">Right operand.</param>
        /// <returns>Result expression.</returns>
        public static BinaryWrapper FloorMod(ExprPattern lhs, ExprPattern rhs) => Sub(lhs, (FloorDiv(lhs, rhs) * rhs));
    }

    public static partial class NN
    {
        public static Conv2DWrapper Conv2D(ExprPattern input, ExprPattern weights, ExprPattern bias, ExprPattern stride, ExprPattern padding, ExprPattern dilation, PadMode padMode, ExprPattern groups) => new Conv2DWrapper(new CallPattern(new Conv2DPattern(padMode), input, weights, bias, stride, padding, dilation, groups));
        public static CeluWrapper Celu(ExprPattern input, ExprPattern alpha) => new CeluWrapper(new CallPattern(new CeluPattern(), input, alpha));
        public static Conv2DTransposeWrapper Conv2DTranspose(ExprPattern input, ExprPattern weights, ExprPattern bias, ExprPattern outShape, ExprPattern stride, ExprPattern padding, ExprPattern dilation, PadMode padMode, ExprPattern groups) => new Conv2DTransposeWrapper(new CallPattern(new Conv2DTransposePattern(padMode), input, weights, bias, outShape, stride, padding, dilation, groups));
        public static EluWrapper Elu(ExprPattern input, ExprPattern alpha) => new EluWrapper(new CallPattern(new EluPattern(), input, alpha));
        public static LeakyReluWrapper LeakyRelu(ExprPattern input) => new LeakyReluWrapper(new CallPattern(new LeakyReluPattern(), input));
        public static L2NormalizationWrapper L2Normalization(ExprPattern input) => new L2NormalizationWrapper(new CallPattern(new L2NormalizationPattern(), input));
        public static BatchNormalizationWrapper BatchNormalization(ExprPattern input, ExprPattern eps, ExprPattern mom) => new BatchNormalizationWrapper(new CallPattern(new BatchNormalizationPattern(), input, eps, mom));
        public static InstanceNormalizationWrapper InstanceNormalization(ExprPattern input, ExprPattern eps) => new InstanceNormalizationWrapper(new CallPattern(new InstanceNormalizationPattern(), input, eps));
        public static LpNormalizationWrapper LpNormalization(ExprPattern input, ExprPattern axis, ExprPattern p) => new LpNormalizationWrapper(new CallPattern(new LpNormalizationPattern(), input, axis, p));
        public static LRNWrapper LRN(ExprPattern input, ExprPattern alpha, ExprPattern beta, ExprPattern bias, ExprPattern size) => new LRNWrapper(new CallPattern(new LRNPattern(), input, alpha, beta, bias, size));
        public static HardSigmoidWrapper HardSigmoid(ExprPattern input, ExprPattern alpha, ExprPattern beta) => new HardSigmoidWrapper(new CallPattern(new HardSigmoidPattern(), input, alpha, beta));
        public static HardSwishWrapper HardSwish(ExprPattern input) => new HardSwishWrapper(new CallPattern(new HardSwishPattern(), input));
        public static ReluWrapper Relu(ExprPattern input) => new ReluWrapper(new CallPattern(new ReluPattern(), input));
        public static Relu6Wrapper Relu6(ExprPattern input) => new Relu6Wrapper(new CallPattern(new Relu6Pattern(), input));
        public static PReluWrapper PRelu(ExprPattern input) => new PReluWrapper(new CallPattern(new PReluPattern(), input));
        public static SeluWrapper Selu(ExprPattern input) => new SeluWrapper(new CallPattern(new SeluPattern(), input));
        public static SigmoidWrapper Sigmoid(ExprPattern expr) => new SigmoidWrapper(new CallPattern(new SigmoidPattern(), expr));
        public static SoftMaxWrapper SoftMax(ExprPattern expr, ExprPattern axis) => new SoftMaxWrapper(new CallPattern(new SoftMaxPattern(), expr, axis));
        public static SoftPlusWrapper SoftPlus(ExprPattern expr) => new SoftPlusWrapper(new CallPattern(new SoftPlusPattern(), expr));
        public static SoftSignWrapper SoftSign(ExprPattern expr) => new SoftSignWrapper(new CallPattern(new SoftSignPattern(), expr));
        public static LogSoftMaxWrapper LogSoftMax(ExprPattern expr, ExprPattern axis) => new LogSoftMaxWrapper(new CallPattern(new LogSoftMaxPattern(), expr, axis));
    }

    public static partial class Tensors
    {
        public static TransposeWrapper Transpose(ExprPattern input, ExprPattern perm) => new TransposeWrapper(new CallPattern(new TransposePattern(), input, perm));
        public static ExprPattern NHWCToNCHW(ExprPattern input) => Transpose(input, new[]{0, 3, 1, 2});
        public static ExprPattern NCHWToNHWC(ExprPattern input) => Transpose(input, new[]{0, 2, 3, 1});
        public static BroadcastWrapper Broadcast(ExprPattern input, ExprPattern shape) => new BroadcastWrapper(new CallPattern(new BroadcastPattern(), input, shape));
        public static CastWrapper Cast(ExprPattern input, DataType newType) => new CastWrapper(new CallPattern(new CastPattern(newType), input));
        public static ConcatWrapper Concat(TuplePattern input, ExprPattern axis) => new ConcatWrapper(new CallPattern(new ConcatPattern(), input, axis));
        public static CumSumWrapper CumSum(ExprPattern input, ExprPattern axis, ExprPattern exclusive, ExprPattern reverse) => new CumSumWrapper(new CallPattern(new CumSumPattern(), input, axis, exclusive, reverse));
        public static HardMaxWrapper HardMax(ExprPattern input, ExprPattern axis) => new HardMaxWrapper(new CallPattern(new CumSumPattern(), input, axis));
        public static GatherWrapper Gather(ExprPattern input, ExprPattern axis, ExprPattern index) => new GatherWrapper(new CallPattern(new GatherPattern(), input, axis, index));
        public static GatherNDWrapper GatherND(ExprPattern input, ExprPattern batch_dims, ExprPattern index) => new GatherNDWrapper(new CallPattern(new GatherNDPattern(), input, batch_dims, index));
        public static MatMulWrapper MatMul(ExprPattern input, ExprPattern other) => new MatMulWrapper(new CallPattern(new MatMulPattern(), input, other));
        public static OneHotWrapper OneHot(OneHotMode oneHotMode, ExprPattern indices, ExprPattern depth, ExprPattern onValue, ExprPattern offValue, ExprPattern axis) => new OneHotWrapper(new CallPattern(new OneHotPattern(oneHotMode), indices, depth, onValue, offValue, axis));
        /// <summary>
        /// Pads is Const tensor, shape = [channels, 2(before, after)]
        /// </summary>
        public static PadWrapper Pad(ExprPattern input, ExprPattern pads, PadMode mode, ExprPattern value) => new PadWrapper(new CallPattern(new PadPattern(mode), input, pads, value));
        public static RandomNormalWrapper RandomNormal(DataType type, ExprPattern mean, ExprPattern scale, ExprPattern seed, ExprPattern shape) => new RandomNormalWrapper(new CallPattern(new RandomNormalPattern(type), mean, scale, seed, shape));
        public static RandomNormalLikeWrapper RandomNormalLike(DataType type, ExprPattern input, ExprPattern mean, ExprPattern scale, ExprPattern seed) => new RandomNormalLikeWrapper(new CallPattern(new RandomNormalPattern(type), input, mean, scale, seed));
        public static RandomUniformWrapper RandomUniform(DataType type, ExprPattern high, ExprPattern low, ExprPattern seed, ExprPattern shape) => new RandomUniformWrapper(new CallPattern(new RandomUniformPattern(type), high, low, seed, shape));
        public static RandomUniformLikeWrapper RandomUniformLike(DataType type, ExprPattern input, ExprPattern high, ExprPattern low, ExprPattern seed) => new RandomUniformLikeWrapper(new CallPattern(new RandomUniformLikePattern(type), input, high, low, seed));
        public static ReduceWrapper Reduce(ReduceOp reduceOp, ExprPattern input, ExprPattern axis, ExprPattern initValue, ExprPattern keepDims) => new ReduceWrapper(new CallPattern(new ReducePattern(reduceOp), input, axis, initValue, keepDims));
        public static ReduceArgWrapper ReduceArg(ReduceArgOp reduceArgOp, ExprPattern input, ExprPattern axis, ExprPattern keepDims, ExprPattern selectLastIndex) => new ReduceArgWrapper(new CallPattern(new ReduceArgPattern(reduceArgOp), input, axis, keepDims, selectLastIndex));
        public static ReduceWrapper ReduceMean(ExprPattern input, ExprPattern axis, ExprPattern initValue, ExprPattern keepDims) => Reduce(ReduceOp.Mean, input, axis, initValue, keepDims);
        public static ReduceWrapper ReduceMin(ExprPattern input, ExprPattern axis, ExprPattern initValue, ExprPattern keepDims) => Reduce(ReduceOp.Min, input, axis, initValue, keepDims);
        public static ReduceWrapper ReduceMax(ExprPattern input, ExprPattern axis, ExprPattern initValue, ExprPattern keepDims) => Reduce(ReduceOp.Min, input, axis, initValue, keepDims);
        public static ReduceWrapper ReduceSum(ExprPattern input, ExprPattern axis, ExprPattern initValue, ExprPattern keepDims) => Reduce(ReduceOp.Sum, input, axis, initValue, keepDims);
        public static ResizeImageWrapper ResizeImage(ImageResizeMode resizeMode, ExprPattern input, ExprPattern newSize, ExprPattern alignCorners, ExprPattern halfPixelCenters) => new ResizeImageWrapper(new CallPattern(new ResizeImagePattern(resizeMode), input, newSize, alignCorners, halfPixelCenters));
        public static ReduceWindow2DWrapper ReduceWindow2D(ReduceOp reduceOp, ExprPattern input, ExprPattern initValue, ExprPattern filter, ExprPattern stride, ExprPattern padding, ExprPattern ceilMode, ExprPattern countIncludePad) => new ReduceWindow2DWrapper(new CallPattern(new ReduceWindow2DPattern(reduceOp), input, initValue, filter, stride, padding, ceilMode, countIncludePad));
        public static ReshapeWrapper Reshape(ExprPattern input, ExprPattern shape) => new ReshapeWrapper(new CallPattern(new ReshapePattern(), input, shape));
        public static ShapeOpWrapper ShapeOp(ExprPattern input) => new ShapeOpWrapper(new CallPattern(new ShapeOpPattern(), input));
        ///https://github.com/onnx/onnx/blob/master/docs/Operators.md#slice
        public static SliceWrapper Slice(ExprPattern input, ExprPattern begins, ExprPattern ends, ExprPattern axes, ExprPattern strides) => new SliceWrapper(new CallPattern(new SlicePattern(), input, begins, ends, axes, strides));
        public static SliceWrapper Slice(ExprPattern input, ExprPattern begins, ExprPattern ends, int rank)
        {
            var axes = Const.FromSpan<int>(Enumerable.Range(0, rank).ToArray());
            var strides = axes with {Data = new IRBytes(DataTypes.GetBytes<int>(Enumerable.Repeat(1, rank).ToArray()))};
            return new SliceWrapper(new CallPattern(new SlicePattern(), input, begins, ends, axes, strides));
        }

        public static ExprPattern Size(ExprPattern input) => ReduceSum(ShapeOp(input), 0, 0, false);
        public static StackWrapper Stack(ExprPattern inputs, ExprPattern axis) => new StackWrapper(new CallPattern(new StackPattern(), inputs, axis));
        /// squeeze input by give dims
        public static SqueezeWrapper Squeeze(ExprPattern input, ExprPattern dims) => new SqueezeWrapper(new CallPattern(new SqueezePattern(), input, dims));
        public static UnSqueezeWrapper UnSqueeze(ExprPattern input, ExprPattern dims) => new UnSqueezeWrapper(new CallPattern(new UnSqueezePattern(), input, dims));
        public static QuantizeWrapper Quantize(ExprPattern input, ExprPattern zeroPoint, ExprPattern scale, DataType targetType) => new QuantizeWrapper(new CallPattern(new QuantizePattern(targetType), input, zeroPoint, scale));
        public static DeQuantizeWrapper DeQuantize(ExprPattern input, ExprPattern zeroPoint, ExprPattern scale, DataType targetType) => new DeQuantizeWrapper(new CallPattern(new DeQuantizePattern(targetType), input, zeroPoint, scale));
        // same like tensorflow
        public static SpaceToBatchWrapper SpaceToBatch(ExprPattern input, ExprPattern blockShape, ExprPattern paddings) => new SpaceToBatchWrapper(new CallPattern(new SpaceToBatchPattern(), input, blockShape, paddings));
        public static BatchToSpaceWrapper BatchToSpace(ExprPattern input, ExprPattern blockShape, ExprPattern crops) => new BatchToSpaceWrapper(new CallPattern(new BatchToSpacePattern(), input, blockShape, crops));
        // sections (int or list[int])
        public static SplitWrapper Split(ExprPattern input, ExprPattern axis, ExprPattern sections) => new SplitWrapper(new CallPattern(new SplitPattern(), input, axis, sections));
    }
}