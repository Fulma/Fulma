namespace Fulma.Extensions

open Fulma.BulmaClasses
open Fulma.Common
open Fable.Core
open Fable.Core.JsInterop
open Fable.Helpers.React
open Fable.Helpers.React.Props
open Fable.Import

module Switch =

    module Styles =
        let [<Literal>] Switch = "switch"
        let [<Literal>] IsRounded = "is-rounded"
        let [<Literal>] IsOutlined = "is-outlined"


    module Types =
        type Option =
            | Level of ILevelAndColor
            | Size of ISize
            | IsOutlined
            | IsRounded
            | IsChecked of bool
            | IsDisabled of bool
            | Value of string // String ???
            | Label of string
            | Props of IHTMLProp list
            | OnChange of (React.FormEvent -> unit)
            | CustomClass of string
            | ComponentId of string
            
        let ofStyles style =
            match style with
            | IsOutlined -> Styles.IsOutlined
            | IsRounded -> Styles.IsRounded
            | value -> failwithf "%A isn't a valid style value" value


        type ComponentId = string
        type Options =
            { Level : string option
              Size : string option
              IsOutlined : bool
              IsRounded : bool
              IsChecked : bool
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
                  IsOutlined = false
                  IsRounded = false
                  IsChecked = false
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

    // States
    let isChecked =  IsChecked true
    let isDisabled = IsDisabled true

    // Styles
    let isOutlined = IsOutlined
    let isRounded = IsRounded


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

    let switchInline (options : Option list) children =

        let parseOptions (result: Options) opt =
            match opt with
            | Option.Level level -> { result with Level = ofLevelAndColor level |> Some }
            | Size size -> { result with Size = ofSize size |> Some }
            | IsOutlined -> { result with IsOutlined  = true }
            | IsRounded -> { result with IsRounded  = true }
            | IsChecked state -> { result with IsChecked = state }
            | IsDisabled state -> { result with IsDisabled = state }
            | Value value -> { result with Value = value }
            | Label label -> { result with Label = label } 
            | Props props -> { result with Props = props }
            | CustomClass customClass -> { result with CustomClass = Some customClass }
            | OnChange cb -> { result with OnChange = cb |> Some }
            | ComponentId customId -> {result with ComponentId = customId }

        let opts = options |> List.fold parseOptions Options.Empty

        [ input 
            [ yield classBaseList
                (Helpers.generateClassName Styles.Switch [ opts.Level; opts.Size; ])
                 [ Styles.IsOutlined, opts.IsOutlined
                   Styles.IsRounded, opts.IsRounded
                   opts.CustomClass.Value, opts.CustomClass.IsSome ] :> IHTMLProp
              if opts.OnChange.IsSome then
                yield Checked opts.IsChecked :> IHTMLProp
                yield DOMAttr.OnChange opts.OnChange.Value :> IHTMLProp
              else
                yield DefaultChecked opts.IsChecked :> IHTMLProp
              yield! opts.Props 
              yield Type "checkbox" :> IHTMLProp
              yield Id opts.ComponentId :> IHTMLProp
              yield Disabled opts.IsDisabled :> IHTMLProp

            ]

          label [ HtmlFor opts.ComponentId ] 
                [ match children with
                      | [] -> yield str opts.Label
                      | _ -> yield! children

                ]
        ]

    
    let switch (options : Option list) children =
        div [ ClassName "field" ] (switchInline options children)