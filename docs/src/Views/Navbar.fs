module Navbar

open Fable.Helpers.React
open Fable.Helpers.React.Props
open Fulma
open Fulma.Components
open Fulma.Elements
open Fulma.Elements.Form
open Fulma.Extra.FontAwesome

let private navButton classy href icon txt =
    Control.control [ ]
        [ Button.button [ Button.CustomClass classy
                          Button.Props [ Href href ] ]
            [ Icon.faIcon [ ]
                [ Fa.icon icon ]
              span [] [ str txt ] ] ]

let private navButtons =
    Field.field [ Field.IsGrouped ]
        [ navButton "twitter" "https://twitter.com/FableCompiler" Fa.I.Twitter "Twitter"
          navButton "github" "https://github.com/MangelMaxime/Fulma/" Fa.I.Github "Github"
          navButton "github" "https://gitter.im/fable-compiler/Fable" Fa.I.Comments "Gitter" ]

let view =
    Navbar.navbar [ Navbar.Color IsPrimary ]
        [ Navbar.Start.div [ ]
            [ Navbar.Brand.div [ ]
                [ Heading.h1 [ ]
                    [ img [ Src "assets/mini_logo.svg"
                            Alt "logo"
                            Style [ MarginRight "10px"
                                    Height "32px" ] ] ] ]
              Navbar.Item.a [ ]
                [ Heading.h4 [ ]
                    [ str "Fulma" ] ] ]
          Navbar.Item.div [ ]
            [ navButtons ] ]
