import { Union, Record } from "./.fable/fable-library.3.1.10/Types.js";
import { union_type, record_type, string_type } from "./.fable/fable-library.3.1.10/Reflection.js";
import { Cmd_none } from "./.fable/Fable.Elmish.3.0.6/cmd.fs.js";
import { body, Option, hero } from "./.fable/Fulma.2.8.1/Layouts/Hero.fs.js";
import { ofArray, empty, singleton } from "./.fable/fable-library.3.1.10/List.js";
import { container } from "./.fable/Fulma.2.8.1/Layouts/Container.fs.js";
import { Option as Option_1, columns } from "./.fable/Fulma.2.8.1/Layouts/Columns.fs.js";
import { ISize, Option as Option_2, column } from "./.fable/Fulma.2.8.1/Layouts/Column.fs.js";
import { Screen } from "./.fable/Fulma.2.8.1/Common.fs.js";
import { Option as Option_3, image } from "./.fable/Fulma.2.8.1/Elements/Image.fs.js";
import * as react from "react";
import { div } from "./.fable/Fulma.2.8.1/Elements/Form/Field.fs.js";
import { label } from "./.fable/Fulma.2.8.1/Elements/Form/Label.fs.js";
import { div as div_1 } from "./.fable/Fulma.2.8.1/Elements/Form/Control.fs.js";
import { IInputType, Option as Option_4, input } from "./.fable/Fulma.2.8.1/Elements/Form/Input.fs.js";
import { Browser_Types_Event__Event_get_Value } from "./.fable/Fable.React.5.3.6/Fable.React.Extensions.fs.js";
import { HTMLAttr } from "./.fable/Fable.React.5.3.6/Fable.React.Props.fs.js";
import { content } from "./.fable/Fulma.2.8.1/Elements/Content.fs.js";
import { icon } from "./.fable/Fulma.2.8.1/Elements/Icon.fs.js";
import { Fa_IconOption, Fa_i } from "./.fable/Fable.FontAwesome.2.0.0/FontAwesome.fs.js";
import { ProgramModule_mkProgram, ProgramModule_run } from "./.fable/Fable.Elmish.3.0.6/program.fs.js";
import { Program_withReactSynchronous } from "./.fable/Fable.Elmish.React.3.0.1/react.fs.js";

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
    return [new Model(msg.fields[0]), Cmd_none()];
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

ProgramModule_run(Program_withReactSynchronous("elmish-app", ProgramModule_mkProgram(init, (msg, model) => update(msg, model), (model_1, dispatch) => view(model_1, dispatch))));

