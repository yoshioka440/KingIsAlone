using UnityEngine;
using System.Collections;
using System.IO;
using UnityEditor;
using System.Xml.Serialization;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;

public class mtb_enemy_spawn_rate_importer : AssetPostprocessor {
	private static readonly string filePath = "Assets/Resources/Data/mtb_enemy_spawn_rate.xls";
	private static readonly string exportPath = "Assets/Resources/Data/mtb_enemy_spawn_rate.asset";
	private static readonly string[] sheetNames = { "SpawnEnemy", };
	
	static void OnPostprocessAllAssets (string[] importedAssets, string[] deletedAssets, string[] movedAssets, string[] movedFromAssetPaths)
	{
		foreach (string asset in importedAssets) {
			if (!filePath.Equals (asset))
				continue;
				
			Entity_SpawnEnemy data = (Entity_SpawnEnemy)AssetDatabase.LoadAssetAtPath (exportPath, typeof(Entity_SpawnEnemy));
			if (data == null) {
				data = ScriptableObject.CreateInstance<Entity_SpawnEnemy> ();
				AssetDatabase.CreateAsset ((ScriptableObject)data, exportPath);
				data.hideFlags = HideFlags.NotEditable;
			}
			
			data.sheets.Clear ();
			using (FileStream stream = File.Open (filePath, FileMode.Open, FileAccess.Read)) {
				IWorkbook book = new HSSFWorkbook (stream);
				
				foreach(string sheetName in sheetNames) {
					ISheet sheet = book.GetSheet(sheetName);
					if( sheet == null ) {
						Debug.LogError("[QuestData] sheet not found:" + sheetName);
						continue;
					}

					Entity_SpawnEnemy.Sheet s = new Entity_SpawnEnemy.Sheet ();
					s.name = sheetName;
				
					for (int i=1; i< sheet.LastRowNum; i++) {
						IRow row = sheet.GetRow (i);
						ICell cell = null;
						
						Entity_SpawnEnemy.Param p = new Entity_SpawnEnemy.Param ();
						
					cell = row.GetCell(0); p.enable = (cell == null ? false : cell.BooleanCellValue);
					if(!p.enable) continue;
					cell = row.GetCell(1); p.id = (int)(cell == null ? 0 : cell.NumericCellValue);
					cell = row.GetCell(2); p.kind = (cell == null ? "" : cell.StringCellValue);
					cell = row.GetCell(3); p.line = (int)(cell == null ? 0 : cell.NumericCellValue);
					cell = row.GetCell(4); p.spawn_time = (float)(cell == null ? 0 : cell.NumericCellValue);
					cell = row.GetCell(5); p.hit_point = (int)(cell == null ? 0 : cell.NumericCellValue);
					cell = row.GetCell(6); p.speed = (float)(cell == null ? 0 : cell.NumericCellValue);
						s.list.Add (p);
					}
					data.sheets.Add(s);
				}
			}

			ScriptableObject obj = AssetDatabase.LoadAssetAtPath (exportPath, typeof(ScriptableObject)) as ScriptableObject;
			EditorUtility.SetDirty (obj);
		}
	}
}
