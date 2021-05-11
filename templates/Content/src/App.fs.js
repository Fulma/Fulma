import { Union, Record } from "./.fable/fable-library.3.1.10/Types.js";
import { getCaseFields, getCaseName as getCaseName_1, isUnion, union_type, record_type, string_type } from "./.fable/fable-library.3.1.10/Reflection.js";
import { Cmd_batch, Cmd_map, Cmd_none } from "./.fable/Fable.Elmish.3.1.0/cmd.fs.js";
import { body, Option, hero } from "./.fable/Fulma.2.10.1/Layouts/Hero.fs.js";
import { cons, ofArray, empty, singleton } from "./.fable/fable-library.3.1.10/List.js";
import { container } from "./.fable/Fulma.2.10.1/Layouts/Container.fs.js";
import { Option as Option_1, columns } from "./.fable/Fulma.2.10.1/Layouts/Columns.fs.js";
import { ISize, Option as Option_2, column } from "./.fable/Fulma.2.10.1/Layouts/Column.fs.js";
import { Screen } from "./.fable/Fulma.2.10.1/Common.fs.js";
import { Option as Option_3, image } from "./.fable/Fulma.2.10.1/Elements/Image.fs.js";
import * as react from "react";
import { div } from "./.fable/Fulma.2.10.1/Elements/Form/Field.fs.js";
import { label } from "./.fable/Fulma.2.10.1/Elements/Form/Label.fs.js";
import { div as div_1 } from "./.fable/Fulma.2.10.1/Elements/Form/Control.fs.js";
import { IInputType, Option as Option_4, input } from "./.fable/Fulma.2.10.1/Elements/Form/Input.fs.js";
import { Browser_Types_Event__Event_get_Value } from "./.fable/Fable.React.7.4.0/Fable.React.Extensions.fs.js";
import { HTMLAttr } from "./.fable/Fable.React.7.4.0/Fable.React.Props.fs.js";
import { content } from "./.fable/Fulma.2.10.1/Elements/Content.fs.js";
import { icon } from "./.fable/Fulma.2.10.1/Elements/Icon.fs.js";
import { Fa_IconOption, Fa_i } from "./.fable/Fable.FontAwesome.2.0.0/FontAwesome.fs.js";
import { Program_Internal_withReactSynchronousUsing } from "./.fable/Fable.Elmish.React.3.0.1/react.fs.js";
import { lazyView2With } from "./.fable/Fable.Elmish.HMR.4.1.0/common.fs.js";
import { ProgramModule_map, ProgramModule_runWith, ProgramModule_mkProgram } from "./.fable/Fable.Elmish.3.1.0/program.fs.js";
import { Program_withDebuggerUsing, Debugger_ConnectionOptions, Debugger_showWarning, Debugger_showError } from "./.fable/Fable.Elmish.Debugger.3.2.0/debugger.fs.js";
import { newGuid } from "./.fable/fable-library.3.1.10/Guid.js";
import { add } from "./.fable/fable-library.3.1.10/Map.js";
import { Auto_generateEncoder_Z127D9D79, uint64, int64, decimal } from "./.fable/Thoth.Json.5.1.0/Encode.fs.js";
import { fromValue, Auto_generateDecoder_7848D058, uint64 as uint64_1, int64 as int64_1, decimal as decimal_1 } from "./.fable/Thoth.Json.5.1.0/Decode.fs.js";
import { empty as empty_1 } from "./.fable/Thoth.Json.5.1.0/Extra.fs.js";
import { ExtraCoders } from "./.fable/Thoth.Json.5.1.0/Types.fs.js";
import { uncurry } from "./.fable/fable-library.3.1.10/Util.js";
import { join } from "./.fable/fable-library.3.1.10/String.js";
import { Options$1 } from "./.fable/Fable.Elmish.Debugger.3.2.0/Fable.Import.RemoteDev.fs.js";
import { connectViaExtension } from "remotedev";
import { Internal_saveState, Model$1, Msg$1, Internal_tryRestoreState } from "./.fable/Fable.Elmish.HMR.4.1.0/hmr.fs.js";
import { value as value_9 } from "./.fable/fable-library.3.1.10/Option.js";

export class Model extends Record {
    constructor(Value) {
        super();
        this.Value = Value;
    }
}

export function Model$reflection() {
    return record_type("App.View.Model", [], Model, () => [["Value", string_type]]);
}

export class Msg extends Union {
    constructor(tag, ...fields) {
        super();
        this.tag = (tag | 0);
        this.fields = fields;
    }
    cases() {
        return ["ChangeValue"];
    }
}

export function Msg$reflection() {
    return union_type("App.View.Msg", [], Msg, () => [[["Item", string_type]]]);
}

export function init(_arg1) {
    return [new Model(""), Cmd_none()];
}

function update(msg, model) {
    const newValue = msg.fields[0];
    return [new Model(newValue), Cmd_none()];
}

function view(model, dispatch) {
    return hero(singleton(new Option(5)), singleton(body(empty(), singleton(container(empty(), singleton(columns(singleton(new Option_1(9, "has-text-centered")), singleton(column(ofArray([new Option_2(0, new Screen(0), new ISize(1)), new Option_2(1, new Screen(0), new ISize(1))]), ofArray([image(ofArray([new Option_3(6), new Option_3(25, singleton(["style", {
        margin: "auto",
    }]))]), singleton(react.createElement("img", {
        src: "assets/fulma_logo.svg",
    }))), div(empty(), ofArray([label(empty(), singleton("Enter your name")), div_1(empty(), singleton(input(ofArray([new Option_4(1, new IInputType(0)), new Option_4(13, (ev) => {
        dispatch(new Msg(0, Browser_Types_Event__Event_get_Value(ev)));
    }), new Option_4(8, model.Value), new Option_4(15, singleton(new HTMLAttr(55, true)))]))))])), content(empty(), ofArray(["Hello, ", model.Value, " ", icon(empty(), singleton(Fa_i(singleton(new Fa_IconOption(11, "far fa-smile")), [])))]))]))))))))));
}

(function () {
    let program_4;
    const program_3 = Program_Internal_withReactSynchronousUsing((equal, view_1, state, dispatch_1) => lazyView2With(equal, view_1, state, dispatch_1), "elmish-app", ProgramModule_mkProgram(init, (msg, model) => update(msg, model), (model_1, dispatch) => view(model_1, dispatch)));
    try {
        let patternInput;
        try {
            let coders;
            let extra_6;
            const extra_3 = new ExtraCoders((() => {
                let copyOfStruct = newGuid();
                return copyOfStruct;
            })(), add("System.Decimal", [(value) => decimal(value), (path) => ((value_1) => decimal_1(path, value_1))], empty_1.Coders));
            extra_6 = (new ExtraCoders((() => {
                let copyOfStruct_1 = newGuid();
                return copyOfStruct_1;
            })(), add("System.Int64", [(value_3) => int64(value_3), int64_1], extra_3.Coders)));
            coders = (new ExtraCoders((() => {
                let copyOfStruct_2 = newGuid();
                return copyOfStruct_2;
            })(), add("System.UInt64", [(value_5) => uint64(value_5), uint64_1], extra_6.Coders)));
            const encoder_3 = Auto_generateEncoder_Z127D9D79(void 0, coders, void 0, {
                ResolveType: Model$reflection,
            });
            const decoder_3 = Auto_generateDecoder_7848D058(void 0, coders, {
                ResolveType: Model$reflection,
            });
            const deflate = (x) => {
                try {
                    return encoder_3(x);
                }
                catch (er) {
                    Debugger_showWarning(singleton(er.message));
                    return x;
                }
            };
            const inflate = (x_1) => {
                const matchValue = fromValue("$", uncurry(2, decoder_3), x_1);
                if (matchValue.tag === 1) {
                    const er_1 = matchValue.fields[0];
                    throw (new Error(er_1));
                }
                else {
                    const x_2 = matchValue.fields[0];
                    return x_2;
                }
            };
            patternInput = [deflate, inflate];
        }
        catch (er_2) {
            Debugger_showWarning(singleton(er_2.message));
            patternInput = [(value_7) => value_7, (_arg1) => {
                throw (new Error("Cannot inflate model"));
            }];
        }
        const inflater = patternInput[1];
        const deflater = patternInput[0];
        let connection;
        const opt = new Debugger_ConnectionOptions(0);
        const makeMsgObj = (tupledArg) => {
            const case$ = tupledArg[0];
            const fields = tupledArg[1];
            return {
                type: case$,
                msg: fields,
            };
        };
        const getCase = (x_3) => {
            if (isUnion(x_3)) {
                const getCaseName = (acc_mut, x_4_mut) => {
                    getCaseName:
                    while (true) {
                        const acc = acc_mut, x_4 = x_4_mut;
                        const acc_1 = cons(getCaseName_1(x_4), acc);
                        const fields_1 = getCaseFields(x_4);
                        if ((fields_1.length === 1) ? isUnion(fields_1[0]) : false) {
                            acc_mut = acc_1;
                            x_4_mut = fields_1[0];
                            continue getCaseName;
                        }
                        else {
                            return makeMsgObj([join("/", acc_1), fields_1]);
                        }
                        break;
                    }
                };
                return getCaseName(empty(), x_3);
            }
            else {
                return makeMsgObj(["NOT-AN-F#-UNION", x_3]);
            }
        };
        const fallback = new Options$1(true, 443, "remotedev.io", true, (arg00) => getCase(arg00));
        connection = connectViaExtension((opt.tag === 1) ? (() => {
            const port = opt.fields[1] | 0;
            const address = opt.fields[0];
            const inputRecord_1 = fallback;
            return new Options$1(inputRecord_1.remote, port, address, false, inputRecord_1.getActionType);
        })() : ((opt.tag === 2) ? (() => {
            const port_1 = opt.fields[1] | 0;
            const address_1 = opt.fields[0];
            const inputRecord_2 = fallback;
            return new Options$1(inputRecord_2.remote, port_1, address_1, inputRecord_2.secure, inputRecord_2.getActionType);
        })() : (new Options$1(false, 8000, "localhost", false, fallback.getActionType))));
        program_4 = Program_withDebuggerUsing(deflater, inflater, connection, program_3);
    }
    catch (ex) {
        Debugger_showError(ofArray(["Unable to connect to the monitor, continuing w/o debugger", ex.message]));
        program_4 = program_3;
    }
    let hmrState = null;
    const hot = module.hot;
    if (!(hot == null)) {
        window.Elmish_HMR_Count = ((window.Elmish_HMR_Count == null) ? 0 : (window.Elmish_HMR_Count + 1));
        const value_8 = hot.accept();
        const matchValue_1 = Internal_tryRestoreState(hot);
        if (matchValue_1 == null) {
        }
        else {
            const previousState = value_9(matchValue_1);
            hmrState = previousState;
        }
    }
    const map = (tupledArg_1) => {
        const model_2 = tupledArg_1[0];
        const cmd = tupledArg_1[1];
        return [model_2, Cmd_map((arg0) => (new Msg$1(0, arg0)), cmd)];
    };
    const mapUpdate = (update_1, msg_1, model_3) => {
        let msg_2, userModel, patternInput_1, newModel, cmd_2;
        const patternInput_2 = map((msg_1.tag === 1) ? [new Model$1(0), Cmd_none()] : (msg_2 = msg_1.fields[0], (model_3.tag === 1) ? (userModel = model_3.fields[0], (patternInput_1 = update_1(msg_2, userModel), (newModel = patternInput_1[0], (cmd_2 = patternInput_1[1], [new Model$1(1, newModel), cmd_2])))) : [model_3, Cmd_none()]));
        const newModel_1 = patternInput_2[0];
        const cmd_3 = patternInput_2[1];
        hmrState = newModel_1;
        return [newModel_1, cmd_3];
    };
    const createModel = (tupledArg_2) => {
        const model_4 = tupledArg_2[0];
        const cmd_4 = tupledArg_2[1];
        return [new Model$1(1, model_4), cmd_4];
    };
    const mapInit = (init_1) => {
        if (hmrState == null) {
            return (arg_2) => createModel(map(init_1(arg_2)));
        }
        else {
            return (_arg1_1) => [hmrState, Cmd_none()];
        }
    };
    const mapSetState = (setState, model_5, dispatch_2) => {
        if (model_5.tag === 1) {
            const userModel_1 = model_5.fields[0];
            setState(userModel_1, (arg_3) => dispatch_2(new Msg$1(0, arg_3)));
        }
    };
    let hmrSubscription;
    const handler = (dispatch_3) => {
        if (!(hot == null)) {
            hot.dispose((data) => {
                Internal_saveState(data, hmrState);
                return dispatch_3(new Msg$1(1));
            });
        }
    };
    hmrSubscription = singleton(handler);
    const mapSubscribe = (subscribe, model_6) => {
        if (model_6.tag === 1) {
            const userModel_2 = model_6.fields[0];
            return Cmd_batch(ofArray([Cmd_map((arg0_2) => (new Msg$1(0, arg0_2)), subscribe(userModel_2)), hmrSubscription]));
        }
        else {
            return Cmd_none();
        }
    };
    const mapView = (view_2, model_7, dispatch_4) => {
        if (model_7.tag === 1) {
            const userModel_3 = model_7.fields[0];
            return view_2(userModel_3, (arg_4) => dispatch_4(new Msg$1(0, arg_4)));
        }
        else {
            throw (new Error("\nYour are using HMR and this Elmish application has been marked as inactive.\n\nYou should not see this message\n                    "));
        }
    };
    ProgramModule_runWith(void 0, ProgramModule_map(uncurry(2, mapInit), mapUpdate, mapView, mapSetState, mapSubscribe, program_4));
})();

