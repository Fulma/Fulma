namespace Fulma.Elements

open Fulma.BulmaClasses
open Fulma.Common
open Fable.Helpers.React
open Fable.Helpers.React.Props

[<RequireQualifiedAccess>]
module Image =
    module Types =
        type IImageSize =
            | Is16x16
            | Is24x24
            | Is32x32
            | Is48x48
            | Is64x64
            | Is96x96
            | Is128x128

        type IImageRatio =
            | IsSquare
            | Is1by1
            | Is4by3
            | Is3by2
            | Is16by9
            | Is2by1

        let ofImageSize =
            function
            | Is16x16 -> Bulma.Image.Size.Is16x16
            | Is24x24 -> Bulma.Image.Size.Is24x24
            | Is32x32 -> Bulma.Image.Size.Is32x32
            | Is48x48 -> Bulma.Image.Size.Is48x48
            | Is64x64 -> Bulma.Image.Size.Is64x64
            | Is96x96 -> Bulma.Image.Size.Is96x96
            | Is128x128 -> Bulma.Image.Size.Is128x128

        let ofImageRatio =
            function
            | IsSquare -> Bulma.Image.Ratio.IsSquare
            | Is1by1 -> Bulma.Image.Ratio.Is1by1
            | Is4by3 -> Bulma.Image.Ratio.Is4by3
            | Is3by2 -> Bulma.Image.Ratio.Is3by2
            | Is16by9 -> Bulma.Image.Ratio.Is16by9
            | Is2by1 -> Bulma.Image.Ratio.Is2by1

        type Option =
            | Size of IImageSize
            | Ratio of IImageRatio
            | CustomClass of string
            | Props of IHTMLProp list

        type Options =
            { Size : string option
              Ratio : string option
              CustomClass : string option
              Props : IHTMLProp list }
            static member Empty =
                { Size = None
                  Ratio = None
                  CustomClass = None
                  Props = [] }

    open Types

    // Sizes
    let inline is16x16<'T> = Size Is16x16
    let inline is24x24<'T> = Size Is24x24
    let inline is32x32<'T> = Size Is32x32
    let inline is48x48<'T> = Size Is48x48
    let inline is64x64<'T> = Size Is64x64
    let inline is96x96<'T> = Size Is96x96
    let inline is128x128<'T> = Size Is128x128
    // Ratios
    let inline isSquare<'T> = Ratio IsSquare
    let inline is1by1<'T> = Ratio Is1by1
    let inline is4by3<'T> = Ratio Is4by3
    let inline is3by2<'T> = Ratio Is3by2
    let inline is16by9<'T> = Ratio Is16by9
    let inline is2by1<'T> = Ratio Is2by1
    // Extra
    let inline customClass x = CustomClass x
    let inline props x = Props x

    let image options children =
        let parseOptions (result : Options) =
            function
            | Size size -> { result with Size = ofImageSize size |> Some }
            | Ratio ratio -> { result with Ratio = ofImageRatio ratio |> Some }
            | CustomClass customClass -> { result with CustomClass = customClass |> Some }
            | Props props -> { result with Props = props }

        let opts = options |> List.fold parseOptions Options.Empty
        figure
            [ yield ClassName(Helpers.generateClassName
                                    Bulma.Image.Container
                                    [ opts.Size; opts.Ratio; opts.CustomClass ]) :> IHTMLProp
              yield! opts.Props ]
            children
