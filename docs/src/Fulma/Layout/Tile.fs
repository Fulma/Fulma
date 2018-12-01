module Layouts.Tile

open Fable.Helpers.React
open Fable.Helpers.React.Props
open Fulma

let iconInteractive () =
    Tile.ancestor [ ]
        [ Tile.parent [ Tile.IsVertical
                        Tile.Size Tile.Is4 ]
            [ Tile.child [ ]
                [ Box.box' [ ]
                    [ Heading.p [ ]
                        [ str "Tile n°1" ]
                      p [ ]
                        [ str "Nulla at urna iaculis, eleifend dolor eget, pellentesque eros. Mauris luctus pharetra velit, viverra feugiat nibh \
                                vehicula vitae. Suspendisse vitae sem id." ] ] ]
              Tile.child [ ]
                [ Box.box' [ ]
                    [ Heading.p [ ]
                        [ str "Tile n°2" ]
                      p [ ]
                        [ str "Curabitur pretium nisi tortor, vitae elementum justo blandit sit amet. Pellentesque vel commodo metus. \
                                In scelerisque pretium quam, quis varius lectus maximus sed." ] ] ]
            ]
          Tile.parent [ ]
            [ Tile.child [ ]
                [ Box.box' [ Common.Props [ Style [ Height "100%" ] ] ]
                    [ Heading.p [ ]
                        [ str "Tile n°3" ]
                      p [ ]
                        [ str "Etiam quis neque efficitur, iaculis urna eget, efficitur ligula. Cras faucibus, magna eu eleifend maximus, ligula \
                                ex gravida libero, vitae suscipit velit nibh eget eros." ]
                      p [ ]
                        [ str "Suspendisse vel turpis nisi. Fusce at risus accumsan, varius massa id, dictum est. Aenean consequat neque \
                                sed tincidunt eleifend." ]
                      p [ ]
                        [ str "Phasellus ac lectus in ex condimentum sollicitudin. Sed id mollis turpis. Sed at \
                                felis vel diam interdum viverra." ] ] ] ] ]

let view =
    Render.docPage [ Render.contentFromMarkdown
                        """
# Tile

A **single tile** element to build 2-dimensional Metro-like, Pinterest-like, or whatever-you-like grids

*[Bulma documentation](http://bulma.io/documentation/layout/tiles/)*

**Important**

In Bulma, you would generally apply the `tile` class directly to your components.

```html
<div class="tile box">
</div>
```

However with Fulma, we can't provide you a wrapper to work that way. So instead, we create a "tile div" and you place you child in it.

```html
<div class="tile">
    <div class="box"></div>
</div>
```

This is important because you will probably need to add `style="height: 100%"` to your child element to make it take the whole tile height.

                        """
                     Render.docSection
                        ""
                        (Widgets.Showcase.view iconInteractive (Render.includeCode __LINE__ __SOURCE_FILE__)) ]
