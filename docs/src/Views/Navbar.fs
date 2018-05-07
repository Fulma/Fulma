module Navbar

open Fable.Helpers.React
open Fable.Helpers.React.Props
open Fulma
open Fulma.FontAwesome

let private navButton classy href icon txt =
    Control.div [ ]
        [ Button.a [ Button.CustomClass classy
                     Button.Props [ Href href ] ]
            [ Icon.faIcon [ ]
                [ Fa.icon icon ]
              span [] [ str txt ] ] ]

let private navButtons =
    Field.div [ Field.IsGrouped ]
        [ navButton "twitter" "https://twitter.com/FableCompiler" Fa.I.Twitter "Twitter"
          navButton "github" "https://github.com/MangelMaxime/Fulma/" Fa.I.Github "Github"
          navButton "github" "https://gitter.im/fable-compiler/Fable" Fa.I.Comments "Gitter" ]

let view =
    Navbar.navbar [ Navbar.Color (IsCustomColor "fulma") ]
        [ Container.container [ ]
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
                [ navButtons ] ] ]
