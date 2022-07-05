using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class InteractiveTiles : MonoBehaviour
{
    [SerializeField] Tile Asset40;
    [SerializeField] Tile Asset41;
    [SerializeField] Tile Column;
    [SerializeField] Tile column_downshadow;
    [SerializeField] Tile columnup;
    [SerializeField] Tile Dirt;
    [SerializeField] Tile Dirtdown;
    [SerializeField] Tile DirtLeft;
    [SerializeField] Tile Dirtleftcorner;
    [SerializeField] Tile Dirtright;
    [SerializeField] Tile Dirtrightconer;
    [SerializeField] Tile grass;
    [SerializeField] Tile Grasscliffleft;
    [SerializeField] Tile Grasscliffmid;
    [SerializeField] Tile Grasscliffright;
    [SerializeField] Tile GrassHillLeft;
    [SerializeField] Tile GrassHillLeftdownshadow;
    [SerializeField] Tile GrassHillRight;
    [SerializeField] Tile GrassHillLeft2;
    [SerializeField] Tile GrassHillRight2;
    [SerializeField] Tile GrassHillRight2Downshadow;
    [SerializeField] Tile GrassJoinHillLeft;
    [SerializeField] Tile GrassJoinHillLeft2;
    [SerializeField] Tile GrassJoinHillLeft2Downshadow;
    [SerializeField] Tile GrassJoinHillRight;
    [SerializeField] Tile GrassJoinHillRight2;
    [SerializeField] Tile GrassJoinHillRight2Downshadow;
    [SerializeField] Tile GrassJoinHillRight2andLeft2;
    [SerializeField] Tile GrassJoinHillRight2ShadowandLeft2Shadow;
    [SerializeField] Tile GrassJoinHillRightandLeft;
    [SerializeField] Tile GrassLeft;
    [SerializeField] Tile GrassMid;
    [SerializeField] Tile GrassRight;
    [SerializeField] Tile GrassSample2;

    enum Tile_Type
    {
        Unknown,
Asset40,
Asset41,
Column,
column_downshadow,
columnup,
Dirtdown,
DirtLeft,
Dirtleftcorner,
Dirtright,
Dirtrightcorner,
grass,
Grasscliffleft,
Grasscliffmid,
Grasscliffright,
GrassHillLeft,
GrassHillLeftdownshadow,
GrassHillRight,
GrassHillLeft2,
GrassHillRight2,
GrassHillRight2Downshadow,
GrassJoinHillLeft,
GrassJoinHillLeft2,
GrassJoinHillLeft2Downshadow,
GrassJoinHillRight,
GrassJoinHillRight2,
GrassJoinHillRight2Downshadow,
GrassJoinHillRight2andLeft2,
GrassJoinHillRight2ShadowandLeft2Shadow,
GrassJoinHillRightandLeft,
GrassLeft,
GrassMid,
GrassRight,
GrassSample2,
    }
enum Tile_Location
    {
        N, E, S, W
    }
    List<object> localTiles;
    List<Tile_Type> localTileTypes; 

    Tilemap tilemap;
    Vector3 mousePos;
    Vector3Int tilePos;

    Vector3Int nTilePos;
    Vector3Int wTilePos;
    Vector3Int sTilePos;
    Vector3Int eTilePos;
    Tile nTile;
    Tile sTile;
    Tile wTile;
    Tile eTile;


    [SerializeField] GridLayout grid;
    // Start is called before the first frame update
    void Start()
    {
        tilemap = GetComponent<Tilemap>();
    }

    // Update is called once per frame
    void Update()
    {

        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        tilePos = grid.WorldToCell(mousePos);
        if (Input.GetMouseButtonUp(0))
        {
            GetLocalTiles(tilePos);
            tilemap.SetTile(tilePos, null);
            SetLocalTiles(tilePos);

        }
    }
    Tile_Type GetTileType (Tile tile)
    {
        if (tile == Asset40) { return Tile_Type.Asset40; }
        if (tile == Asset41) { return Tile_Type.Asset41; }
        if (tile == Column) { return Tile_Type.Column; }
        if (tile == column_downshadow) { return Tile_Type.column_downshadow; }
        if (tile == columnup) { return Tile_Type.columnup; }
        if (tile == Dirtdown) { return Tile_Type.Dirtdown; }
        if (tile == DirtLeft) { return Tile_Type.DirtLeft; }
        if (tile == Dirtleftcorner) { return Tile_Type.Dirtleftcorner; }
        if (tile == Dirtright) { return Tile_Type.Dirtright; }
        if (tile == Dirtrightconer) { return Tile_Type.Dirtrightcorner; }
        if (tile == grass) { return Tile_Type.grass; }
        if (tile == Grasscliffleft) { return Tile_Type.Grasscliffleft; }
        if (tile == Grasscliffmid) { return Tile_Type.Grasscliffmid; }
        if (tile == Grasscliffright) { return Tile_Type.Grasscliffright; }
        if (tile == GrassHillLeft) { return Tile_Type.GrassHillLeft; }
        if (tile == GrassHillLeftdownshadow) { return Tile_Type.GrassHillLeftdownshadow; }
        if (tile == GrassHillRight) { return Tile_Type.GrassHillRight; }
        if (tile == GrassHillLeft2) { return Tile_Type.GrassHillLeft2; }
        if (tile == GrassHillRight2) { return Tile_Type.GrassHillRight2; }
        if (tile == GrassHillRight2Downshadow) { return Tile_Type.GrassHillRight2Downshadow; }
        if (tile == GrassJoinHillLeft) { return Tile_Type.GrassJoinHillLeft; }
        if (tile == GrassJoinHillLeft2) { return Tile_Type.GrassJoinHillLeft2; }
        if (tile == GrassJoinHillLeft2Downshadow) { return Tile_Type.GrassJoinHillLeft2Downshadow; }
        if (tile == GrassJoinHillRight) { return Tile_Type.GrassJoinHillRight; }
        if (tile == GrassJoinHillRight2) { return Tile_Type.GrassJoinHillRight2; }
        if (tile == GrassJoinHillRight2Downshadow) { return Tile_Type.GrassJoinHillRight2Downshadow; }
        if (tile == GrassJoinHillRight2andLeft2) { return Tile_Type.GrassJoinHillRight2andLeft2; }
        if (tile == GrassJoinHillRight2ShadowandLeft2Shadow) { return Tile_Type.GrassJoinHillRight2ShadowandLeft2Shadow; }
        if (tile == GrassJoinHillRightandLeft) { return Tile_Type.GrassJoinHillRightandLeft; }
        if (tile == GrassLeft) { return Tile_Type.GrassLeft; }
        if (tile == GrassMid) { return Tile_Type.GrassMid; }
        if (tile == GrassRight) { return Tile_Type.GrassRight; }
        if (tile == GrassSample2) { return Tile_Type.GrassSample2; }
        return Tile_Type.Unknown;
    }

    void GetLocalTiles(Vector3Int tilepos)
    {
        nTilePos = new Vector3Int(tilePos.x, tilePos.y + 1, tilePos.z);
        sTilePos = new Vector3Int(tilePos.x, tilePos.y - 1, tilePos.z);
        wTilePos = new Vector3Int(tilePos.x - 1, tilePos.y, tilePos.z);
        eTilePos = new Vector3Int(tilePos.x + 1, tilePos.y, tilePos.z);
        nTile = tilemap.GetTile<Tile>(nTilePos);
        sTile = tilemap.GetTile<Tile>(sTilePos);
        wTile = tilemap.GetTile<Tile>(wTilePos);
        eTile = tilemap.GetTile<Tile>(eTilePos);
        localTiles = new List<object> { nTile, eTile, sTile, wTile };
        localTileTypes = new List<Tile_Type> { GetTileType(nTile), GetTileType(eTile), GetTileType(sTile), GetTileType(eTile) };
    }
    void UpdateTile(Tile_Location loc)
    {
        switch (loc)
        {
            case Tile_Location.N:
                switch (localTileTypes[0])
                {
                    case Tile_Type.Asset40:
                        tilemap.SetTile(nTilePos, Asset40);
                        break;
                    case Tile_Type.Asset41:
                        tilemap.SetTile(nTilePos, Asset41);
                        break;
                    case Tile_Type.Column:
                        tilemap.SetTile(nTilePos, Column);
                        break;
                    case Tile_Type.column_downshadow:
                        tilemap.SetTile(nTilePos, column_downshadow);
                        break;
                    case Tile_Type.columnup:
                        tilemap.SetTile(nTilePos, Column);
                        break;
                    case Tile_Type.Dirtdown:
                        tilemap.SetTile(nTilePos, Dirtdown);
                        break;
                    case Tile_Type.DirtLeft:
                        tilemap.SetTile(nTilePos, DirtLeft);
                        break;
                    case Tile_Type.Dirtleftcorner:
                        tilemap.SetTile(nTilePos, Dirtleftcorner);
                        break;
                    case Tile_Type.Dirtright:
                        tilemap.SetTile(nTilePos, Dirtright);
                        break;
                    case Tile_Type.Dirtrightcorner:
                        tilemap.SetTile(nTilePos, Dirtrightconer);
                        break;
                    case Tile_Type.grass:
                        tilemap.SetTile(nTilePos, grass);
                        break;
                    case Tile_Type.Grasscliffleft:
                        tilemap.SetTile(nTilePos, Grasscliffleft);
                        break;
                    case Tile_Type.Grasscliffmid:
                        tilemap.SetTile(nTilePos, Grasscliffmid);
                        break;
                    case Tile_Type.Grasscliffright:
                        tilemap.SetTile(nTilePos, Grasscliffright);
                        break;
                    case Tile_Type.GrassHillLeft:
                        tilemap.SetTile(nTilePos, GrassHillLeft);
                        break;
                    case Tile_Type.GrassHillLeftdownshadow:
                        tilemap.SetTile(nTilePos, GrassHillLeftdownshadow);
                        break;
                    case Tile_Type.GrassHillRight:
                        tilemap.SetTile(nTilePos, GrassHillRight);
                        break;
                    case Tile_Type.GrassHillLeft2:
                        tilemap.SetTile(nTilePos, GrassHillLeft2);
                        break;
                    case Tile_Type.GrassHillRight2:
                        tilemap.SetTile(nTilePos, GrassHillRight2);
                        break;
                    case Tile_Type.GrassHillRight2Downshadow:
                        tilemap.SetTile(nTilePos, GrassHillRight2Downshadow);
                        break;
                    case Tile_Type.GrassJoinHillLeft:
                        tilemap.SetTile(nTilePos, GrassJoinHillLeft);
                        break;
                    case Tile_Type.GrassJoinHillLeft2:
                        tilemap.SetTile(nTilePos, GrassJoinHillLeft2);
                        break;
                    case Tile_Type.GrassJoinHillLeft2Downshadow:
                        tilemap.SetTile(nTilePos, Dirt);
                        break;
                    case Tile_Type.GrassJoinHillRight:
                        tilemap.SetTile(nTilePos, Dirt);
                        break;
                    case Tile_Type.GrassJoinHillRight2:
                        tilemap.SetTile(nTilePos, GrassJoinHillRight2);
                        break;
                    case Tile_Type.GrassJoinHillRight2Downshadow:
                        tilemap.SetTile(nTilePos, GrassJoinHillRight2Downshadow);
                        break;
                    case Tile_Type.GrassJoinHillRight2andLeft2:
                        tilemap.SetTile(nTilePos, GrassJoinHillRight2andLeft2);
                        break;
                    case Tile_Type.GrassJoinHillRight2ShadowandLeft2Shadow:
                        tilemap.SetTile(nTilePos, GrassJoinHillRight2ShadowandLeft2Shadow);
                        break;
                    case Tile_Type.GrassJoinHillRightandLeft:
                        tilemap.SetTile(nTilePos, GrassJoinHillRightandLeft);
                        break;
                    case Tile_Type.GrassLeft:
                        tilemap.SetTile(nTilePos, GrassLeft);
                        break;
                    case Tile_Type.GrassMid:
                        tilemap.SetTile(nTilePos, GrassMid);
                        break;
                    case Tile_Type.GrassRight:
                        tilemap.SetTile(nTilePos, GrassRight);
                        break;
                    case Tile_Type.GrassSample2:
                        tilemap.SetTile(nTilePos, GrassSample2);
                        break;
                }

                break;
            case Tile_Location.S:
                switch (localTileTypes[1])
                {
                    case Tile_Type.Asset40:
                        tilemap.SetTile(sTilePos, Asset40);
                        break;
                    case Tile_Type.Asset41:
                        tilemap.SetTile(sTilePos, Asset41);
                        break;
                    case Tile_Type.Column:
                        tilemap.SetTile(sTilePos, Column);
                        break;
                    case Tile_Type.column_downshadow:
                        tilemap.SetTile(sTilePos, column_downshadow);
                        break;
                    case Tile_Type.columnup:
                        tilemap.SetTile(sTilePos, Column);
                        break;
                    case Tile_Type.Dirtdown:
                        tilemap.SetTile(sTilePos, Dirtdown);
                        break;
                    case Tile_Type.DirtLeft:
                        tilemap.SetTile(sTilePos, DirtLeft);
                        break;
                    case Tile_Type.Dirtleftcorner:
                        tilemap.SetTile(sTilePos, Dirtleftcorner);
                        break;
                    case Tile_Type.Dirtright:
                        tilemap.SetTile(sTilePos, Dirtright);
                        break;
                    case Tile_Type.Dirtrightcorner:
                        tilemap.SetTile(sTilePos, Dirtrightconer);
                        break;
                    case Tile_Type.grass:
                        tilemap.SetTile(sTilePos, grass);
                        break;
                    case Tile_Type.Grasscliffleft:
                        tilemap.SetTile(sTilePos, Grasscliffleft);
                        break;
                    case Tile_Type.Grasscliffmid:
                        tilemap.SetTile(sTilePos, Grasscliffmid);
                        break;
                    case Tile_Type.Grasscliffright:
                        tilemap.SetTile(sTilePos, Grasscliffright);
                        break;
                    case Tile_Type.GrassHillLeft:
                        tilemap.SetTile(sTilePos, GrassHillLeft);
                        break;
                    case Tile_Type.GrassHillLeftdownshadow:
                        tilemap.SetTile(sTilePos, GrassHillLeftdownshadow);
                        break;
                    case Tile_Type.GrassHillRight:
                        tilemap.SetTile(sTilePos, GrassHillRight);
                        break;
                    case Tile_Type.GrassHillLeft2:
                        tilemap.SetTile(sTilePos, GrassHillLeft2);
                        break;
                    case Tile_Type.GrassHillRight2:
                        tilemap.SetTile(sTilePos, GrassHillRight2);
                        break;
                    case Tile_Type.GrassHillRight2Downshadow:
                        tilemap.SetTile(sTilePos, GrassHillRight2Downshadow);
                        break;
                    case Tile_Type.GrassJoinHillLeft:
                        tilemap.SetTile(sTilePos, GrassJoinHillLeft);
                        break;
                    case Tile_Type.GrassJoinHillLeft2:
                        tilemap.SetTile(sTilePos, GrassJoinHillLeft2);
                        break;
                    case Tile_Type.GrassJoinHillLeft2Downshadow:
                        tilemap.SetTile(sTilePos, Dirt);
                        break;
                    case Tile_Type.GrassJoinHillRight:
                        tilemap.SetTile(sTilePos, Dirt);
                        break;
                    case Tile_Type.GrassJoinHillRight2:
                        tilemap.SetTile(sTilePos, GrassJoinHillRight2);
                        break;
                    case Tile_Type.GrassJoinHillRight2Downshadow:
                        tilemap.SetTile(sTilePos, GrassJoinHillRight2Downshadow);
                        break;
                    case Tile_Type.GrassJoinHillRight2andLeft2:
                        tilemap.SetTile(sTilePos, GrassJoinHillRight2andLeft2);
                        break;
                    case Tile_Type.GrassJoinHillRight2ShadowandLeft2Shadow:
                        tilemap.SetTile(sTilePos, GrassJoinHillRight2ShadowandLeft2Shadow);
                        break;
                    case Tile_Type.GrassJoinHillRightandLeft:
                        tilemap.SetTile(sTilePos, GrassJoinHillRightandLeft);
                        break;
                    case Tile_Type.GrassLeft:
                        tilemap.SetTile(sTilePos, GrassLeft);
                        break;
                    case Tile_Type.GrassMid:
                        tilemap.SetTile(sTilePos, GrassMid);
                        break;
                    case Tile_Type.GrassRight:
                        tilemap.SetTile(sTilePos, GrassRight);
                        break;
                    case Tile_Type.GrassSample2:
                        tilemap.SetTile(sTilePos, GrassSample2);
                        break;
                }
                break;
            case Tile_Location.W:
                switch (localTileTypes[2])
                {
                    case Tile_Type.Asset40:
                        tilemap.SetTile(wTilePos, Asset40);
                        break;
                    case Tile_Type.Asset41:
                        tilemap.SetTile(wTilePos, Asset41);
                        break;
                    case Tile_Type.Column:
                        tilemap.SetTile(wTilePos, Column);
                        break;
                    case Tile_Type.column_downshadow:
                        tilemap.SetTile(wTilePos, column_downshadow);
                        break;
                    case Tile_Type.columnup:
                        tilemap.SetTile(wTilePos, Column);
                        break;
                    case Tile_Type.Dirtdown:
                        tilemap.SetTile(wTilePos, Dirtdown);
                        break;
                    case Tile_Type.DirtLeft:
                        tilemap.SetTile(wTilePos, DirtLeft);
                        break;
                    case Tile_Type.Dirtleftcorner:
                        tilemap.SetTile(wTilePos, Dirtleftcorner);
                        break;
                    case Tile_Type.Dirtright:
                        tilemap.SetTile(wTilePos, Dirtright);
                        break;
                    case Tile_Type.Dirtrightcorner:
                        tilemap.SetTile(wTilePos, Dirtrightconer);
                        break;
                    case Tile_Type.grass:
                        tilemap.SetTile(wTilePos, grass);
                        break;
                    case Tile_Type.Grasscliffleft:
                        tilemap.SetTile(wTilePos, Grasscliffleft);
                        break;
                    case Tile_Type.Grasscliffmid:
                        tilemap.SetTile(wTilePos, Grasscliffmid);
                        break;
                    case Tile_Type.Grasscliffright:
                        tilemap.SetTile(wTilePos, Grasscliffright);
                        break;
                    case Tile_Type.GrassHillLeft:
                        tilemap.SetTile(wTilePos, GrassHillLeft);
                        break;
                    case Tile_Type.GrassHillLeftdownshadow:
                        tilemap.SetTile(wTilePos, GrassHillLeftdownshadow);
                        break;
                    case Tile_Type.GrassHillRight:
                        tilemap.SetTile(wTilePos, GrassHillRight);
                        break;
                    case Tile_Type.GrassHillLeft2:
                        tilemap.SetTile(wTilePos, GrassHillLeft2);
                        break;
                    case Tile_Type.GrassHillRight2:
                        tilemap.SetTile(wTilePos, GrassHillRight2);
                        break;
                    case Tile_Type.GrassHillRight2Downshadow:
                        tilemap.SetTile(wTilePos, GrassHillRight2Downshadow);
                        break;
                    case Tile_Type.GrassJoinHillLeft:
                        tilemap.SetTile(wTilePos, GrassJoinHillLeft);
                        break;
                    case Tile_Type.GrassJoinHillLeft2:
                        tilemap.SetTile(wTilePos, GrassJoinHillLeft2);
                        break;
                    case Tile_Type.GrassJoinHillLeft2Downshadow:
                        tilemap.SetTile(wTilePos, Dirt);
                        break;
                    case Tile_Type.GrassJoinHillRight:
                        tilemap.SetTile(wTilePos, Dirt);
                        break;
                    case Tile_Type.GrassJoinHillRight2:
                        tilemap.SetTile(wTilePos, GrassJoinHillRight2);
                        break;
                    case Tile_Type.GrassJoinHillRight2Downshadow:
                        tilemap.SetTile(wTilePos, GrassJoinHillRight2Downshadow);
                        break;
                    case Tile_Type.GrassJoinHillRight2andLeft2:
                        tilemap.SetTile(wTilePos, GrassJoinHillRight2andLeft2);
                        break;
                    case Tile_Type.GrassJoinHillRight2ShadowandLeft2Shadow:
                        tilemap.SetTile(wTilePos, GrassJoinHillRight2ShadowandLeft2Shadow);
                        break;
                    case Tile_Type.GrassJoinHillRightandLeft:
                        tilemap.SetTile(wTilePos, GrassJoinHillRightandLeft);
                        break;
                    case Tile_Type.GrassLeft:
                        tilemap.SetTile(wTilePos, GrassLeft);
                        break;
                    case Tile_Type.GrassMid:
                        tilemap.SetTile(wTilePos, GrassMid);
                        break;
                    case Tile_Type.GrassRight:
                        tilemap.SetTile(wTilePos, GrassRight);
                        break;
                    case Tile_Type.GrassSample2:
                        tilemap.SetTile(wTilePos, GrassSample2);
                        break;
                }
                break;
            case Tile_Location.E:
                switch (localTileTypes[3])
                    {
                    case Tile_Type.Asset40:
                        tilemap.SetTile(eTilePos, Asset40);
                        break;
                    case Tile_Type.Asset41:
                        tilemap.SetTile(eTilePos, Asset41);
                        break;
                    case Tile_Type.Column:
                        tilemap.SetTile(eTilePos, Column);
                        break;
                    case Tile_Type.column_downshadow:
                        tilemap.SetTile(eTilePos, column_downshadow);
                        break;
                    case Tile_Type.columnup:
                        tilemap.SetTile(eTilePos, Column);
                        break;
                    case Tile_Type.Dirtdown:
                        tilemap.SetTile(eTilePos, Dirtdown);
                        break;
                    case Tile_Type.DirtLeft:
                        tilemap.SetTile(eTilePos, DirtLeft);
                        break;
                    case Tile_Type.Dirtleftcorner:
                        tilemap.SetTile(eTilePos, Dirtleftcorner);
                        break;
                    case Tile_Type.Dirtright:
                        tilemap.SetTile(eTilePos, Dirtright);
                        break;
                    case Tile_Type.Dirtrightcorner:
                        tilemap.SetTile(eTilePos, Dirtrightconer);
                        break;
                    case Tile_Type.grass:
                        tilemap.SetTile(eTilePos, grass);
                        break;
                    case Tile_Type.Grasscliffleft:
                        tilemap.SetTile(eTilePos, Grasscliffleft);
                        break;
                    case Tile_Type.Grasscliffmid:
                        tilemap.SetTile(eTilePos, Grasscliffmid);
                        break;
                    case Tile_Type.Grasscliffright:
                        tilemap.SetTile(eTilePos, Grasscliffright);
                        break;
                    case Tile_Type.GrassHillLeft:
                        tilemap.SetTile(eTilePos, GrassHillLeft);
                        break;
                    case Tile_Type.GrassHillLeftdownshadow:
                        tilemap.SetTile(eTilePos, GrassHillLeftdownshadow);
                        break;
                    case Tile_Type.GrassHillRight:
                        tilemap.SetTile(eTilePos, GrassHillRight);
                        break;
                    case Tile_Type.GrassHillLeft2:
                        tilemap.SetTile(eTilePos, GrassHillLeft2);
                        break;
                    case Tile_Type.GrassHillRight2:
                        tilemap.SetTile(eTilePos, GrassHillRight2);
                        break;
                    case Tile_Type.GrassHillRight2Downshadow:
                        tilemap.SetTile(eTilePos, GrassHillRight2Downshadow);
                        break;
                    case Tile_Type.GrassJoinHillLeft:
                        tilemap.SetTile(eTilePos, GrassJoinHillLeft);
                        break;
                    case Tile_Type.GrassJoinHillLeft2:
                        tilemap.SetTile(eTilePos, GrassJoinHillLeft2);
                        break;
                    case Tile_Type.GrassJoinHillLeft2Downshadow:
                        tilemap.SetTile(eTilePos, Dirt);
                        break;
                    case Tile_Type.GrassJoinHillRight:
                        tilemap.SetTile(eTilePos, Dirt);
                        break;
                    case Tile_Type.GrassJoinHillRight2:
                        tilemap.SetTile(eTilePos, GrassJoinHillRight2);
                        break;
                    case Tile_Type.GrassJoinHillRight2Downshadow:
                        tilemap.SetTile(eTilePos, GrassJoinHillRight2Downshadow);
                        break;
                    case Tile_Type.GrassJoinHillRight2andLeft2:
                        tilemap.SetTile(eTilePos, GrassJoinHillRight2andLeft2);
                        break;
                    case Tile_Type.GrassJoinHillRight2ShadowandLeft2Shadow:
                        tilemap.SetTile(eTilePos, GrassJoinHillRight2ShadowandLeft2Shadow);
                        break;
                    case Tile_Type.GrassJoinHillRightandLeft:
                        tilemap.SetTile(eTilePos, GrassJoinHillRightandLeft);
                        break;
                    case Tile_Type.GrassLeft:
                        tilemap.SetTile(eTilePos, GrassLeft);
                        break;
                    case Tile_Type.GrassMid:
                        tilemap.SetTile(eTilePos, GrassMid);
                        break;
                    case Tile_Type.GrassRight:
                        tilemap.SetTile(eTilePos, GrassRight);
                        break;
                    case Tile_Type.GrassSample2:
                        tilemap.SetTile(eTilePos, GrassSample2);
                        break;
                }
                break;

        }
    }
    void SetLocalTiles(Vector3Int tilePos)
    {
        foreach(Tile_Location loc in Tile_Location.GetValues(typeof(Tile_Location)))
        {
            UpdateTile(loc);
        }
    }
}

