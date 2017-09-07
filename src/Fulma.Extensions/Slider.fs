namespace Fulma.Extensions

open Fulma.BulmaClasses
open Fulma.Common
open Fable.Import
open Fable.Helpers.React
open Fable.Helpers.React.Props

module Slider =

    module Classes =
        let [<Literal>] Slider  = "slider "
        let [<Literal>] IsCircle = "is-circle"
        let [<Literal>] IsFullwidth = "is-fullwidth"


    module Types =

        type ISize =
            | IsSmall
            | IsMedium
            | IsLarge
            | IsFullWidth
            | Nothing


        type Option =
            | Level of ILevelAndColor
            | Size of ISize
            | IsCircle
            | IsDisabled of bool
            | Value of string // String ???
            | Label of string
            | Props of IHTMLProp list
            | OnChange of (React.FormEvent -> unit)
            | CustomClass of string
            | ComponentId of string
            
        let ofSize size =
            match size with
            | IsSmall -> Bulma.Modifiers.Size.IsSmall
            | IsMedium -> Bulma.Modifiers.Size.IsMedium
            | IsLarge -> Bulma.Modifiers.Size.IsLarge
            | IsFullWidth -> Classes.IsFullwidth
            | ISize.Nothing -> ""

        let ofStyles style =
            match style with
            | IsCircle -> Classes.IsCircle
            | value -> failwithf "%A isn't a valid style value" value


        type ComponentId = string
        type Options =
            { Level : string option
              Size : string option
              IsCircle : bool
              IsDisabled : bool
              Value : string
              Label : string
              Props : IHTMLProp list
              CustomClass : string option
              OnChange : (React.FormEvent -> unit) option
              ComponentId: string }
            static member Empty =
                { Level = None
                  Size = None
                  IsCircle = false
                  IsDisabled = false
                  Value = ""
                  Label = ""
                  Props = []
                  CustomClass = None
                  OnChange = None
                  ComponentId = System.Guid.NewGuid() |> sprintf "%O" }

    open Types

    // Sizes
    let isSmall = Size IsSmall
    let isMedium = Size IsMedium
    let isLarge = Size IsLarge
    let isFullWidth = Size IsFullWidth

    // States
    let isDisabled = IsDisabled true

    // Styles
    let isCircle = IsCircle


    // Levels and colors
    let isBlack = Level IsBlack
    let isDark = Level IsDark
    let isLight = Level IsLight
    let isWhite = Level IsWhite
    let isPrimary = Level IsPrimary
    let isInfo = Level IsInfo
    let isSuccess = Level IsSuccess
    let isWarning = Level IsWarning
    let isDanger = Level IsDanger

    // Label and Value
    let value data  = Value data
    let text s = Label s

    // Extra
    let props props = Props props
    let customClass = CustomClass
    
    let onChange cb = OnChange cb

    let slider (options : Option list) children =


        let parseOptions (result: Options) opt =
            match opt with
            | Option.Level level -> { result with Level = ofLevelAndColor level |> Some }
            | Size size -> { result with Size = ofSize size |> Some }
            | IsCircle -> { result with IsCircle  = true }
            | IsDisabled state -> { result with IsDisabled = state }
            | Value value -> { result with Value = value }
            | Label label -> { result with Label = label } 
            | Props props -> { result with Props = props }
            | CustomClass customClass -> { result with CustomClass = Some customClass }
            | OnChange cb -> { result with OnChange = cb |> Some }
            | ComponentId customId -> {result with ComponentId = customId }

        let opts = options |> List.fold parseOptions Options.Empty

        input 
            [ yield classBaseList
                (Helpers.generateClassName Classes.Slider [ opts.Level; opts.Size; ])
                 [ Classes.IsCircle, opts.IsCircle
                   opts.CustomClass.Value, opts.CustomClass.IsSome ] :> IHTMLProp
              if opts.OnChange.IsSome then
                yield DOMAttr.OnChange opts.OnChange.Value :> IHTMLProp
              yield! opts.Props 
              yield Type "range" :> IHTMLProp
              yield Id opts.ComponentId :> IHTMLProp
              yield Disabled opts.IsDisabled :> IHTMLProp
            ]