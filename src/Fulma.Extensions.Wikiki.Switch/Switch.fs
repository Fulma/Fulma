namespace Fulma.Extensions.Wikiki

open Fulma
open Fable.React
open Fable.React.Props

[<RequireQualifiedAccess>]
module Switch =

    module Classes =
        let [<Literal>] Switch = "switch"
        let [<Literal>] IsRounded = "is-rounded"
        let [<Literal>] IsOutlined = "is-outlined"
        let [<Literal>] IsThin = "is-thin"
        let [<Literal>] IsRtl = "is-rtl"

    type Option =
        | Color of IColor
        | Size of ISize
        /// Add `is-rounded` class
        | [<CompiledName("is-rounded")>] IsOutlined
        /// Add `is-outlined` class
        | [<CompiledName("is-outlined")>] IsRounded
        /// Add `is-thin` class
        | [<CompiledName("is-thin")>] IsThin
        /// Add `is-rtl` class
        | [<CompiledName("is-rtl")>] IsRtl
        /// Set `Checked` HTMLAttr
        | Checked of bool
        /// Set `disabled` HTMLAttr
        | Disabled of bool
        | LabelProps of IHTMLProp list
        | InputProps of IHTMLProp list
        | OnChange of (Browser.Types.Event -> unit)
        | CustomClass of string
        | Id of string

    let private parseOptionsForInput (result : GenericOptions) option =
        match option with
        | Option.Color color -> ofColor color |> result.AddClass
        | Size size -> ofSize size |> result.AddClass
        | IsOutlined
        | IsRounded
        | IsRtl
        | IsThin -> result.AddCaseName option
        | Checked state -> Props.Checked state |> result.AddProp
        | Disabled state -> Props.Disabled state |> result.AddProp
        | InputProps props -> result.AddProps props
        | CustomClass customClass -> result.AddClass customClass
        | OnChange cb -> Props.OnChange cb |> result.AddProp
        | Id customId -> Props.Id customId |> result.AddProp
        // If option abose don't match, then others don't impact the input generation
        | LabelProps _ -> result

    let private parseOptionsForLabel (result : GenericOptions) option =
        match option with
        | Id customId -> Props.HtmlFor customId |> result.AddProp
        | LabelProps props -> result.AddProps props
        // If option abose don't match, then others don't impact the label generation
        | _ -> result

    let private hasId (options : Option list) =
        options
        |> List.tryPick (fun option ->
            match option with
            | Id _ -> Some true
            | _ -> None
        )
        |> Option.isSome

    /// Generate
    /// <fragment>
    ///   <input class="switch" type="checkbox">
    ///   <label>One</label>
    /// </fragment>
    let switchInline (options : Option list) children =

        if hasId options then
            let inputElement =
                GenericOptions.Parse(options, parseOptionsForInput, "switch", [Props.Type "checkbox" ]).ToReactElement(input)

            let labelElement =
                GenericOptions.Parse(options, parseOptionsForLabel).ToReactElement(label, children)

            fragment [ ]
                [ inputElement
                  labelElement ]
        else
            Text.span [ Modifiers [ Modifier.TextColor IsDanger
                                    Modifier.TextWeight TextWeight.Bold ] ]
                [ str "You need to set an Id value for your Switch "]

    /// Generate
    /// <div class="field">
    ///   <fragment>
    ///     <input class="switch" type="checkbox">
    ///     <label>One</label>
    ///   </fragment>
    /// </div>
    let switch (options : Option list) children =
        Field.div [ ]
            [ switchInline options children ]
