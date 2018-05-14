module Fulma.Versions

let view =
    Render.contentFromMarkdown
        """
<center style="width: 200px;margin: auto;">
    ![Fulma logo](assets/logo_transparent.svg)
</center>

Here you can find which version of each library is supported by Fulma.

<table class="table" style="width: auto;">
    <thead>
        <tr>
            <th>Fulma</th>
            <th>Bulma</th>
            <th>Font Awesome</th>
        </tr>
    </thead>
    <tbody>
        <tr>
            <td>Current</td>
            <td>0.7.1</td>
            <td>4.7.0</td>
        </tr>
    </tbody>
<table>
        """
