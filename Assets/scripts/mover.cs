using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using UnityEngine.SceneManagement;

public class load1
{
    static public float tjump;
    static public float jump;
    static public float rjump;
    static public bool islight;
    static public bool isplanet;
    static public RawImage watermask;
    static public float gr; static public float pl;
    static public Color bg; static public CameraClearFlags bg2;
}
public class save
{
    public string idsave;
    public Vector3 pos, pos2;

    public Quaternion q1, q2, q3;
    public Vector3 velosyty; public Vector3 angularvelosyty;
    public float vive;
}
public class tsave
{
    
    public Vector3 pos, pos2;

    public Quaternion q1, q2, q3;
    public Vector3 velosyty; public Vector3 angularvelosyty;
    public float vive;
}
public class gsave
{
    public int progressofthepassage = 0;
    public int hp;
    public float oxygen;
    public bool tp;
    public string idsave;
    public int sceneid;
    public List<string> inventory = new List<string>();
    public List<string> inventoryname = new List<string>();
}

public class mover : MonoBehaviour
{
    public GameObject g;
    public GameObject g2;
    public Rigidbody g1;
    public float sm;
    public save save = new save(); 
    public tsave tsave = new tsave();
    public gsave gsave = new gsave();
    public InputField ifd;
    public float tjump;
    public float jump;
    public float rjump;
    public float gr; public float pl;
    public bool igr;
    public bool isplanet;
    public bool issweming;
    public Collision c;
    public Animator anim;
    public float vive = int.MaxValue;
    public RawImage watermask;
    public float fog; public float fog2;
    public Color fogonwater;
    public Color fogonair = new Color(0, 0, 0, 0);
    public int hp = 200; private float oxygen = 20;
    float tic, time = 4; public float tic2, time2 = 4;
    bool s2 = true;
    bool isthirdperson;
    public GameObject sr;
    public deldialog del;
    public bool islight = false;
    float vel;
    public bool tutorial;
    float tics;
    bool fly; bool Xray;
    public GameObject[] mybody;

    void OnCollisionStay(Collision collision)
    {
        igr = false;
        if (tjump < -2)
        {
            Debug.Log(tjump);
            hp += Mathf.FloorToInt(tjump) / 3;
        }
        tjump = rjump;
        if (issweming)
        {
            igr = false;
            tjump = 0;
        }
        c = collision;
        if (collision.collider.tag == "sc")
        {
            tjump = -rjump / 2;

        }

        if (collision.collider.tag == "sc2")
        {
            if (g1.velocity.y >= 2)
            {
                tic2 += Time.deltaTime;
            }
            if (g1.velocity.y <= 2 && tic2 >= 0)
            {
                tic2 -= Time.deltaTime;
            }
            if (tic2 >= time2)
            {
                tjump = -rjump / 2;
                s2 = false;
                igr = true;

            }
            if (!s2)
            {
                tjump = -rjump / 2;
                s2 = false;
                igr = true;
                tic2 -= Time.deltaTime * 2;
                if (tic2 <= 0)
                {

                    s2 = true;

                }
            }

        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "dead")
        {
            VarSave.SetBool("??????? ???????? ??? ????? ?????? ????? ???", true);
            VarSave.SetBool("cry", true);

            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        }
        if (other.tag == "airhole")
        {
            igr = true;

        }
        if (other.GetComponent<notswiming>())
        {
            issweming = true;

        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "lagi")
        {
            g2.GetComponent<Camera>().enabled = 1 == Random.Range(0, 3);

        }

    }

    private void OnTriggerExit(Collider other)
    {

        if (other.GetComponent<notswiming>())
        {
            issweming = false;

        }
        if (other.tag == "lagi")
        {
            g2.GetComponent<Camera>().enabled = true;

        }
    }
    void OnCollisionExit(Collision collision)
    {

        c = null;
    }
    private void Awake()
    {
        if (isplanet)
        {
            gameObject.AddComponent<PlanetGravity>().body = transform;
            gameObject.GetComponent<PlanetGravity>().gravity = tjump;
            gameObject.GetComponent<Rigidbody>().useGravity = false;
        }
            playerdata.Loadeffect();
        
        ionenergy.energy = 0;
        vel = GetComponent<CapsuleCollider>().height;
        if (Photon.Pun.PhotonNetwork.IsConnected)
        {
            load1.isplanet = isplanet;
            load1.gr = gr;
            load1.jump = jump;
            load1.rjump = rjump;
            load1.tjump = tjump;
            load1.islight = islight;
            load1.pl = pl;
            load1.watermask = watermask;
            load1.bg = g2.GetComponent<Camera>().backgroundColor;
            load1.bg2 = g2.GetComponent<Camera>().clearFlags;
            Photon.Pun.PhotonNetwork.Instantiate("nr", transform.position, Quaternion.identity);
            Destroy(gameObject);

        }
        if (File.Exists("unauticna.license"))
        {
            if (Resources.Load<license>("delux/license").code + Resources.Load<license>("delux/license").version == File.ReadAllText("unauticna.license"))
            {
                for (int i3 = 0; i3 < GameObject.FindGameObjectsWithTag("license").Length; i3++)
                {





                    GameObject.FindGameObjectsWithTag("license")[i3].AddComponent<deleter1>();

                }
            }
        }
        if (File.Exists("unauticna.license"))
        {
            if (Resources.Load<license>("delux/license").code + Resources.Load<license>("delux/license").version != File.ReadAllText("unauticna.license"))
            {
                for (int i3 = 0; i3 < GameObject.FindGameObjectsWithTag("delux").Length; i3++)
                {





                    GameObject.FindGameObjectsWithTag("delux")[i3].AddComponent<deleter1>();

                }
            }
        }
        if (!File.Exists("unauticna.license"))
        {

            for (int i3 = 0; i3 < GameObject.FindGameObjectsWithTag("delux").Length; i3++)
            {





                GameObject.FindGameObjectsWithTag("delux")[i3].AddComponent<deleter1>();

            }

        }
        if (!Photon.Pun.PhotonNetwork.IsConnected && !tutorial)
        {
            Instantiate(Resources.Load<GameObject>("player inventory"));
            WorldSave.GetVector4("var");
            WorldSave.GetVector3("var1");
            WorldSave.GetMusic(SceneManager.GetActiveScene().name);
            Directory.CreateDirectory("unsave");
            Directory.CreateDirectory("unsave/capterg");
            Directory.CreateDirectory("unsave/capter" + SceneManager.GetActiveScene().buildIndex);
            if (File.Exists("unsave/s"))
            {
                ifd.text = File.ReadAllText("unsave/s");
            }
            if (File.Exists("unsave/capter" + SceneManager.GetActiveScene().buildIndex + "/" + ifd.text))
            {
                save = JsonUtility.FromJson<save>(File.ReadAllText("unsave/capter" + SceneManager.GetActiveScene().buildIndex + "/" + ifd.text));
                g1.angularVelocity = save.angularvelosyty;
                g1.velocity = save.velosyty;
                if (!portallNumer.p2 && !portallNumer.p1 && !portallNumer.p3 && !portallNumer.p4 && !portallNumer.p5 && !portallNumer.p6 && !portallNumer.p7 && !portallNumer.p8)
                {
                    g.transform.position = save.pos;
                    sr.transform.position = save.pos2;
                }
                g.transform.rotation = save.q1;
                sr.transform.rotation = save.q3;
                g2.transform.rotation = save.q2;

                Camera.main.fieldOfView = save.vive;

            }
            if (File.Exists("unsave/capterg/" + ifd.text))
            {
                gsave = JsonUtility.FromJson<gsave>(File.ReadAllText("unsave/capterg/" + ifd.text));
                hp = gsave.hp;
                oxygen = gsave.oxygen;
                isthirdperson = gsave.tp;
            }
        }
            if (!Photon.Pun.PhotonNetwork.IsConnected && tutorial)
            {
                Instantiate(Resources.Load<GameObject>("player inventory"));
                WorldSave.GetVector4("var");
                WorldSave.GetVector3("var1");
                WorldSave.GetMusic(SceneManager.GetActiveScene().name);
                Directory.CreateDirectory("unsavet");
                Directory.CreateDirectory("unsavet/capterg");
                Directory.CreateDirectory("unsavet/capter" + SceneManager.GetActiveScene().buildIndex);
                
                    ifd.text = "tutorial";
                
                if (File.Exists("unsavet/capter" + SceneManager.GetActiveScene().buildIndex + "/" + ifd.text))
                {
                    save = JsonUtility.FromJson<save>(File.ReadAllText("unsavet/capter" + SceneManager.GetActiveScene().buildIndex + "/" + ifd.text));
                    g1.angularVelocity = save.angularvelosyty;
                    g1.velocity = save.velosyty;
                    if (!portallNumer.p2 && !portallNumer.p1 && !portallNumer.p3 && !portallNumer.p4)
                    {
                        g.transform.position = save.pos;
                        sr.transform.position = save.pos2;
                    }
                    
                    g.transform.rotation = save.q1;
                    sr.transform.rotation = save.q3;
                    g2.transform.rotation = save.q2;

                    Camera.main.fieldOfView = save.vive;

                }
                if (File.Exists("unsavet/capterg/" + ifd.text))
                {
                    gsave = JsonUtility.FromJson<gsave>(File.ReadAllText("unsavet/capterg/" + ifd.text));
                    hp = gsave.hp;
                    oxygen = gsave.oxygen;
                    isthirdperson = gsave.tp;
                }



            }
        
   }
    void Start()
    {

        fog = RenderSettings.fogStartDistance;
        fog2 = RenderSettings.fogEndDistance;
        if (VarSave.GetBool("cry"))
        {
            Instantiate(Resources.Load<GameObject>("ui/defet/achievement").gameObject, transform.position, Quaternion.identity);

            VarSave.SetBool("cry", false);
        }
        if (VarSave.EnterFloat("mus"))
        {
            for (int i = 0; i < GameObject.FindGameObjectsWithTag("game musig").Length; i++)
            {
                GameObject.FindGameObjectsWithTag("game musig")[i].GetComponent<AudioSource>().volume = VarSave.GetFloat("mus");
            }
        }


    }
    public void load()
    {


        if (Input.GetKey(KeyCode.G))
        {
            DirectoryInfo di = new DirectoryInfo("unsave/capter-" + SceneManager.GetActiveScene().buildIndex);
            if (File.Exists("unsave/capter-" + SceneManager.GetActiveScene().buildIndex + "/" + ifd.text + "-" + (di.GetFiles().Length -1)))
            {
                tsave = JsonUtility.FromJson<tsave>(File.ReadAllText("unsave/capter-" + SceneManager.GetActiveScene().buildIndex + "/" + ifd.text + "-" + (di.GetFiles().Length - 1)));
                g1.angularVelocity = tsave.angularvelosyty;
                g1.velocity = tsave.velosyty;
                g.transform.position = tsave.pos; g2.transform.position = tsave.pos2;
                sr.transform.position = tsave.pos2;
                g.transform.rotation = tsave.q1;
                sr.transform.rotation = tsave.q3;
                g2.transform.rotation = tsave.q2;
                Camera.main.fieldOfView = tsave.vive;
                File.Delete("unsave/capter-" + SceneManager.GetActiveScene().buildIndex + "/" + ifd.text + "-" + (di.GetFiles().Length - 1));
            }
            
        }
        if (!tutorial)
        {
            if (Input.GetKey(KeyCode.F2))
            {
                playerdata.Loadeffect();
                if (File.Exists("unsave/capter" + SceneManager.GetActiveScene().buildIndex + "/" + ifd.text))
                {
                    save = JsonUtility.FromJson<save>(File.ReadAllText("unsave/capter" + SceneManager.GetActiveScene().buildIndex + "/" + ifd.text));
                    g1.angularVelocity = save.angularvelosyty;
                    g1.velocity = save.velosyty;
                    g.transform.position = save.pos; sr.transform.position = save.pos2;
                    g.transform.rotation = save.q1;
                    sr.transform.rotation = save.q3;
                    g2.transform.rotation = save.q2;
                    Camera.main.fieldOfView = save.vive;
                    WorldSave.GetVector4("var"); WorldSave.GetVector3("var1");
                    WorldSave.GetMusic(SceneManager.GetActiveScene().name);
                }
                if (File.Exists("unsave/capterg/" + ifd.text))
                {
                    gsave = JsonUtility.FromJson<gsave>(File.ReadAllText("unsave/capterg/" + ifd.text));
                    hp = gsave.hp;
                    oxygen = gsave.oxygen;
                    isthirdperson = gsave.tp;
                }
            }
        }
        else
        {
            if (Input.GetKey(KeyCode.F2))
            {
                playerdata.Loadeffect();
                if (File.Exists("unsavet/capter" + SceneManager.GetActiveScene().buildIndex + "/" + ifd.text))
                {
                    save = JsonUtility.FromJson<save>(File.ReadAllText("unsavet/capter" + SceneManager.GetActiveScene().buildIndex + "/" + ifd.text));
                    g1.angularVelocity = save.angularvelosyty;
                    g1.velocity = save.velosyty;
                    g.transform.position = save.pos; sr.transform.position = save.pos2;
                    g.transform.rotation = save.q1;
                    sr.transform.rotation = save.q3;
                    g2.transform.rotation = save.q2;
                    Camera.main.fieldOfView = save.vive;
                    WorldSave.GetVector4("var"); WorldSave.GetVector3("var1");
                    WorldSave.GetMusic(SceneManager.GetActiveScene().name);
                }
                if (File.Exists("unsavet/capterg/" + ifd.text))
                {
                    gsave = JsonUtility.FromJson<gsave>(File.ReadAllText("unsavet/capterg/" + ifd.text));
                    hp = gsave.hp;
                    oxygen = gsave.oxygen;
                    isthirdperson = gsave.tp;
                }
            }

        }

    }
    public void stop()
    {
        GetComponent<CapsuleCollider>().height = vel;
        if (tjump < -vel * 2)
        {


            GetComponent<CapsuleCollider>().height += -tjump * 0.5f;
        }
        if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.S))
        {


            g1.velocity = Vector3.zero;
        }

    }
    public void Creaive()
    {
        if (Directory.Exists("debug"))
        {
            if (Input.GetKeyDown(KeyCode.C))
            {
                fly = !fly;
            }
            if (Input.GetKeyDown(KeyCode.U))
            {
                Xray = !Xray;
                saveing();
                if (!Xray)
                {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                }
            }
            if (Xray)
            {
                for (int i = 0; i < GameObject.FindObjectsOfType<MeshRenderer>().Length; i++)
                {
                    GameObject.FindObjectsOfType<MeshRenderer>()[i].enabled = true;
                    GameObject.FindObjectsOfType<MeshRenderer>()[i].material = Resources.Load<Material>("mats/xray");
                    if (GameObject.FindObjectsOfType<MeshRenderer>()[i].gameObject.GetComponent<BoxCollider>())
                    {
                        if (GameObject.FindObjectsOfType<MeshRenderer>()[i].gameObject.GetComponent<BoxCollider>().isTrigger == true)
                        {
                            GameObject.FindObjectsOfType<MeshRenderer>()[i].material = Resources.Load<Material>("mats/xray3");
                        }
                    }
                    }
                for (int i = 0; i < GameObject.FindObjectsOfType<SkinnedMeshRenderer>().Length; i++)
                {
                    GameObject.FindObjectsOfType<SkinnedMeshRenderer>()[i].enabled = true;
                    GameObject.FindObjectsOfType<SkinnedMeshRenderer>()[i].material = Resources.Load<Material>("mats/xray2");
                }
                
            }
            if (fly)
            {
                tjump = 0;
                
                if (Input.GetKey(KeyCode.W))
                {

                    anim.SetBool("swem", true);
                    g1.velocity += g.transform.forward * 30;
                }
                if (Input.GetKey(KeyCode.S))
                {

                    anim.SetBool("swem", true);
                    g1.velocity += -g.transform.forward * 30;
                }
                if (Input.GetKey(KeyCode.D))
                {

                    anim.SetBool("swem", true);
                    g1.velocity += g.transform.right * 30;
                }
                if (Input.GetKey(KeyCode.A))
                {

                    anim.SetBool("swem", true);
                    g1.velocity += -g.transform.right * 30;
                }
                if (Input.GetKey(KeyCode.Space))
                {

                    anim.SetBool("swem", true);
                    g1.velocity += g.transform.up * 30;
                }
                if (Input.GetKey(KeyCode.LeftControl))
                {

                    anim.SetBool("swem", true);
                    g1.velocity -= g.transform.up * 30;
                }

            }
        }
    }
    void Update()
    {
        
        if (isplanet)
        {
            
            gameObject.GetComponent<PlanetGravity>().gravity = tjump;
        }
        if (playerdata.Geteffect("invisible") != null)
        {


            for (int i = 0; i < mybody.Length; i++)
            {
                if (mybody[i].GetComponent<MeshRenderer>())
                {


                    mybody[i].GetComponent<MeshRenderer>().material = Resources.Load<Material>("pm/playermatinvisible");
                }
                if (mybody[i].GetComponent<SkinnedMeshRenderer>())
                {


                    mybody[i].GetComponent<SkinnedMeshRenderer>().material = Resources.Load<Material>("pm/playermatinvisible");
                }
            }
            
            //playermatinvisible
        }
        if (playerdata.Geteffect("invisible") == null)
        {
            for (int i = 0; i < mybody.Length; i++)
            {
                if (mybody[i].GetComponent<MeshRenderer>())
                {


                    mybody[i].GetComponent<MeshRenderer>().material = Resources.Load<Material>("pm/playermat");
                }
                if (mybody[i].GetComponent<SkinnedMeshRenderer>())
                {


                    mybody[i].GetComponent<SkinnedMeshRenderer>().material = Resources.Load<Material>("pm/playermat");
                }
            }
            //playermat
        }
        playerdata.checkeffect();
        musave.GetUF();
        if (File.Exists("unsave/capterg/" + ifd.text)&& Input.GetKeyDown(KeyCode.F3))
        {
            gsave = JsonUtility.FromJson<gsave>(File.ReadAllText("unsave/capterg/" + ifd.text));
            string s = "";
            s = ifd.text;
            File.WriteAllText("unsave/s", s);
            SceneManager.LoadScene(gsave.sceneid);
        }
       
        Ray r1 = new Ray(g2.transform.position, g2.transform.forward);
        RaycastHit hit;
        if (Physics.Raycast(r1, out hit))
        {
            if (hit.collider != null && Input.GetKeyDown(KeyCode.Tab))
            {
                if (hit.collider.GetComponent<transport4>())
                {
                    hit.collider.GetComponent<transport4>().sitplayer = !hit.collider.GetComponent<transport4>().sitplayer;
                    hit.collider.GetComponent<transport4>().player = transform;
                }

            }

        }

        if (!isthirdperson)
        {
            g2.transform.position = sr.transform.position;
        }
        if (isthirdperson)
        {

            Ray r = new Ray(sr.transform.position, -sr.transform.forward);
            RaycastHit hit1;
            if (Physics.Raycast(r, out hit1))
            {
                if (hit1.collider != null)
                {
                    if (hit1.distance < 6)
                    {

                        g2.transform.position = hit1.point;
                    }
                    if (hit1.distance > 6)
                    {

                        g2.transform.position = sr.transform.position - sr.transform.forward * 6;
                    }
                }
                else
                {
                    g2.transform.position = sr.transform.position - sr.transform.forward * 6;
                }

            }
            else
            {
                g2.transform.position = sr.transform.position - sr.transform.forward * 6;
            }
        }
        if (GameObject.FindGameObjectsWithTag("oxy").Length != 0)
        {
            GameObject.FindGameObjectWithTag("oxy").GetComponent<Image>().fillAmount = oxygen / 20;
        }
        if (issweming == true)
        {
            if (!GameObject.FindGameObjectWithTag("oxy"))
            {
                Instantiate(Resources.Load<GameObject>("ui/info/oxygen").gameObject, transform.position, Quaternion.identity);
            }
            oxygen -= Time.deltaTime;
        }
        if (issweming == false && oxygen <= 5)
        {

            oxygen += Time.deltaTime;
        }
        if (issweming == false && oxygen >= 5 && oxygen <= 20)
        {
            if (GameObject.FindGameObjectWithTag("oxy"))
            {
                Destroy(GameObject.FindWithTag("oxy"));
            }
            oxygen += Time.deltaTime * 2;
        }
        if (VarSave.GetBool("partic") && 0 <= GameObject.FindObjectsOfType<ParticleSystem>().Length - 1)
        {
            DestroyImmediate(GameObject.FindObjectsOfType<ParticleSystem>()[0].gameObject);
        }
        tic += Time.deltaTime;
        if (hp <= 0)
        {
            VarSave.SetBool("?????? ?? ???", true);
            VarSave.SetBool("cry", true);

            gsave.hp = 20;


            gsave.idsave = ifd.text;
            gsave.sceneid = SceneManager.GetActiveScene().buildIndex;
            File.WriteAllText("unsave/capterg/" + ifd.text, JsonUtility.ToJson(gsave));
            string s = "";
            s = ifd.text;
            File.WriteAllText("unsave/s", s);
            WorldSave.SetVector4("var");
            WorldSave.SetVector3("var1");

            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        }
        if (oxygen <= 0)
        {
            VarSave.SetBool("oxygen", true);
            VarSave.SetBool("cry", true);

            gsave.oxygen = 20;


            gsave.idsave = ifd.text;
            gsave.sceneid = SceneManager.GetActiveScene().buildIndex;
            File.WriteAllText("unsave/capterg/" + ifd.text, JsonUtility.ToJson(gsave));
            string s = "";
            s = ifd.text;
            File.WriteAllText("unsave/s", s);
            WorldSave.SetVector4("var");
            WorldSave.SetVector3("var1");

            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        }
        if (hp <= 20 && !GameObject.FindWithTag("blood"))
        {
            Instantiate(Resources.Load<GameObject>("ui/damage/blood").gameObject, transform.position, Quaternion.identity);
        }
        if (hp >= 20 && GameObject.FindWithTag("blood"))
        {
            Destroy(GameObject.FindWithTag("blood"));
        }
        if (oxygen <= 5 && !GameObject.FindWithTag("blood1"))
        {
            Instantiate(Resources.Load<GameObject>("ui/damage/blood1").gameObject, transform.position, Quaternion.identity);
        }
        if (oxygen >= 5 && GameObject.FindWithTag("blood1"))
        {
            Destroy(GameObject.FindWithTag("blood1"));
        }
        if (tic >= time && hp < 199)
        {
            hp += 1;
            tic = 0;

        }
        WorldSave.SetMusic(SceneManager.GetActiveScene().name);
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
        g1.velocity = Vector3.zero;
        if (!Input.GetKey(KeyCode.W) || !Input.GetKey(KeyCode.S) || !Input.GetKey(KeyCode.A) || !Input.GetKey(KeyCode.D))
        {
            anim.SetBool("walke", false);
            anim.SetBool("swem", false);
            
        }
        
        float ispeed = 10f;
        if (Input.GetKey(KeyCode.Mouse0) && Directory.Exists("debug"))
        {
            ispeed *= 2.5f;
        }
        if (Directory.Exists("debug"))
        {

            if (Input.GetKeyDown(KeyCode.X) && SceneManager.GetActiveScene().buildIndex < SceneManager.sceneCountInBuildSettings - 1)
            {

                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
            if (Input.GetKeyDown(KeyCode.Z))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
            }
        }
        if (!issweming && !Input.GetKey(KeyCode.F) && !Input.GetKey(KeyCode.G) && del == null && !Input.GetKey(KeyCode.LeftShift))
        {

            RenderSettings.fogStartDistance = fog;
            RenderSettings.fogEndDistance = fog2; if (fogonair.a != 0)
            {
                RenderSettings.fogColor = fogonair;
            }
            if (Input.GetKey(KeyCode.W))
            {

                if (c != null)
                {


                    anim.SetBool("walke", true);
                }
                    g1.velocity += g.transform.forward * ispeed;
            }
            if (Input.GetKey(KeyCode.S))
            {

                if (c != null)
                {


                    anim.SetBool("walke", true);
                }
                g1.velocity += -g.transform.forward * ispeed;
            }
            if (Input.GetKey(KeyCode.D))
            {

                if (c != null)
                {


                    anim.SetBool("walke", true);
                }
                g1.velocity += g.transform.right * ispeed;
            }
            if (Input.GetKey(KeyCode.A))
            {

                if (c != null)
                {


                    anim.SetBool("walke", true);
                }
                g1.velocity += -g.transform.right * ispeed;
            }
        }
        if (c == null)
        {
            anim.SetBool("fall", true);
        }
        if (c != null)
        {
            anim.SetBool("fall", false);
        }
        if (Input.GetKey(KeyCode.F) && Input.GetKey(KeyCode.G))
        {
            g1.useGravity = false;
        }
        if (Input.GetKeyDown(KeyCode.F5))
        {
            g.transform.rotation = Quaternion.identity;
            g2.transform.rotation = sr.transform.rotation;

            isthirdperson = !isthirdperson;
        }
        if (!Input.GetKey(KeyCode.F) && !Input.GetKey(KeyCode.G))
        {
            tics += Time.deltaTime;
            g1.useGravity = true;
        }
        if (Input.GetKey(KeyCode.F) && Input.GetKeyDown(KeyCode.Tab) && Getstats.GetPlayerLevel() >= 1)
        {
            
            if (tics >= 2)
            {
                transform.Translate(0,0,5);
                tics =0;
            }
        }

        if (issweming && !Input.GetKey(KeyCode.F) && !Input.GetKey(KeyCode.G) && del != null && !Input.GetKey(KeyCode.LeftShift))
        {
            if (!del.stopPlayer)
            {


                RenderSettings.fogStartDistance = fog / 2;
                RenderSettings.fogEndDistance = fog2 / 2;
                RenderSettings.fogColor = fogonwater;
                if (Input.GetKey(KeyCode.W))
                {

                    anim.SetBool("swem", true);
                    g1.velocity += g.transform.forward * ispeed / 4;
                }
                if (Input.GetKey(KeyCode.S))
                {

                    anim.SetBool("swem", true);
                    g1.velocity += -g.transform.forward * ispeed / 4;
                }
                if (Input.GetKey(KeyCode.D))
                {

                    anim.SetBool("swem", true);
                    g1.velocity += g.transform.right * ispeed / 4;
                }
                if (Input.GetKey(KeyCode.A))
                {

                    anim.SetBool("swem", true);
                    g1.velocity += -g.transform.right * ispeed / 4;
                }
            }
        }
        if (!issweming && !Input.GetKey(KeyCode.F) && !Input.GetKey(KeyCode.G) && del != null && !Input.GetKey(KeyCode.LeftShift))
        {
            if (!del.stopPlayer)
            {

                RenderSettings.fogStartDistance = fog;
                RenderSettings.fogEndDistance = fog2; if (fogonair.a != 0)
                {
                    RenderSettings.fogColor = fogonair;
                }
                if (Input.GetKey(KeyCode.W))
                {

                    anim.SetBool("walke", true);
                    g1.velocity += g.transform.forward * ispeed;
                }
                if (Input.GetKey(KeyCode.S))
                {

                    anim.SetBool("walke", true);
                    g1.velocity += -g.transform.forward * ispeed;
                }
                if (Input.GetKey(KeyCode.D))
                {

                    anim.SetBool("walke", true);
                    g1.velocity += g.transform.right * ispeed;
                }
                if (Input.GetKey(KeyCode.A))
                {

                    anim.SetBool("walke", true);
                    g1.velocity += -g.transform.right * ispeed;
                }
            }
        }
        if (issweming && !Input.GetKey(KeyCode.F) && !Input.GetKey(KeyCode.G) && del == null && !Input.GetKey(KeyCode.LeftShift))
        {



            RenderSettings.fogStartDistance = fog / 2;
            RenderSettings.fogEndDistance = fog2 / 2;
            RenderSettings.fogColor = fogonwater;
            if (Input.GetKey(KeyCode.W))
            {

                anim.SetBool("swem", true);
                g1.velocity += g.transform.forward * ispeed / 4;
            }
            if (Input.GetKey(KeyCode.S))
            {

                anim.SetBool("swem", true);
                g1.velocity += -g.transform.forward * ispeed / 4;
            }
            if (Input.GetKey(KeyCode.D))
            {

                anim.SetBool("swem", true);
                g1.velocity += g.transform.right * ispeed / 4;
            }
            if (Input.GetKey(KeyCode.A))
            {

                anim.SetBool("swem", true);
                g1.velocity += -g.transform.right * ispeed / 4;
            }

        }
        stop(); if (watermask)
        {


            watermask.enabled = issweming;
        }
        if (Input.GetKey(KeyCode.Mouse1))
        {
            Cursor.lockState = CursorLockMode.Locked;
            if (!isthirdperson)
            {


                g2.transform.Rotate(new Vector3(-Input.GetAxis("Mouse Y") * sm, 0, 0));
            }
            if (isthirdperson)
            {


                sr.transform.Rotate(-Input.GetAxis("Mouse Y") * sm, 0, 0);
            }
            if (!Input.GetKey(KeyCode.LeftShift))
            {

                g.transform.Rotate(new Vector3(0, Input.GetAxis("Mouse X") * sm, 0));
            }

        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
        }

        //"unsave/capter/"+ifd.text
        //Mouse ScrollWheel
        Camera.main.fieldOfView += Input.GetAxis("Mouse ScrollWheel") / vive;
        save.angularvelosyty = g1.angularVelocity;
        save.velosyty = g1.velocity;
        save.q1 = g.transform.rotation;
        save.q2 = g2.transform.rotation;
        save.pos = g.transform.position;
        save.pos2 = sr.transform.position;
        save.q3 = sr.transform.rotation;
        save.vive = Camera.main.fieldOfView;
        gsave.hp = hp;


        if (Input.GetKey(KeyCode.F1) && !tutorial)
        {
            playerdata.Saveeffect();
            save.idsave = ifd.text;
            File.WriteAllText("unsave/capter" + SceneManager.GetActiveScene().buildIndex + "/" + ifd.text, JsonUtility.ToJson(save));
            gsave.idsave = ifd.text;
            gsave.hp = hp;
            gsave.oxygen = oxygen;
            gsave.tp = isthirdperson;
            gsave.sceneid = SceneManager.GetActiveScene().buildIndex;
            File.WriteAllText("unsave/capterg/" + ifd.text, JsonUtility.ToJson(gsave));
            string s = "";
            s = ifd.text;
            File.WriteAllText("unsave/s", s);
            WorldSave.SetVector4("var");
            WorldSave.SetVector3("var1");

        }
        load();
        if (c == null && !issweming && !Input.GetKey(KeyCode.F) && !Input.GetKey(KeyCode.G))
        {
            tjump -= Time.deltaTime * gr;

            g1.velocity += -transform.up * 10;
        }
        if (issweming)
        {
            if (tjump > 0)
            {

                anim.SetBool("swem", true);
                tjump -= 1 * Time.deltaTime * pl;
            }
            if (tjump <= 0)
            {


                tjump = 0;
            }

            g1.velocity += g2.transform.forward * tjump;
            g1.useGravity = false;


            if (tjump >= rjump / 2)
            {
                igr = false;
            }
        }
        if (Input.GetKey(KeyCode.Space) && !igr && !issweming && s2 && !Input.GetKey(KeyCode.LeftShift))
        {
            igr = true;
        }
        if (igr && !issweming && !Input.GetKey(KeyCode.F) && !Input.GetKey(KeyCode.G) && s2)
        {
            g1.velocity += transform.up * jump * tjump;
        }
        if (igr && !issweming && !s2)
        {
            g1.velocity -= transform.up * tjump;
            g1.velocity += -transform.up * -50;
        }

        if (Input.GetKey(KeyCode.Space) && !igr && issweming && tjump < rjump / 2 && !Input.GetKey(KeyCode.LeftShift))
        {
            igr = true;
        }
        if (igr && issweming)
        {
            tjump = rjump;
        }
        if(isplanet)
        {
            
            gameObject.GetComponent<Rigidbody>().useGravity = false;
        }
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            anim.SetBool("sit",true);
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            anim.SetBool("sit", false);
        }
        Creaive();
        timesaveing();
    }
    public void saveing()
    {
        if (playerdata.Geteffect("LevelUp") != null)
        {
            VarSave.SetInt("progress",gsave.progressofthepassage+1);
            gsave.progressofthepassage += 1;
            musave.chargescene(0);

            playerdata.Cleareffect();
        }
            playerdata.Saveeffect();
        
        if (!tutorial)
        {


            if (GameObject.Find("w2"))
            {
                GameObject.Find("w2").GetComponent<pos4>().save();
            }
            save.angularvelosyty = g1.angularVelocity;
            save.velosyty = g1.velocity;
            save.q1 = g.transform.rotation;
            save.q2 = g2.transform.rotation;
            save.pos = g.transform.position;
            save.vive = Camera.main.fieldOfView;
            gsave.hp = hp;
            gsave.oxygen = oxygen;
            gsave.tp = isthirdperson;
            save.idsave = ifd.text;
            File.WriteAllText("unsave/capter" + SceneManager.GetActiveScene().buildIndex + "/" + ifd.text, JsonUtility.ToJson(save));
            gsave.idsave = ifd.text;
            gsave.sceneid = SceneManager.GetActiveScene().buildIndex;
            File.WriteAllText("unsave/capterg/" + ifd.text, JsonUtility.ToJson(gsave));
            string s = "";
            s = ifd.text;
            File.WriteAllText("unsave/s", s);
            WorldSave.SetVector4("var");
            WorldSave.SetVector3("var1");
        }
        else
        {
            if (GameObject.Find("w2"))
            {
                GameObject.Find("w2").GetComponent<pos4>().save();
            }
            save.angularvelosyty = g1.angularVelocity;
            save.velosyty = g1.velocity;
            save.q1 = g.transform.rotation;
            save.q2 = g2.transform.rotation;
            save.pos = g.transform.position;
            save.vive = Camera.main.fieldOfView;
            tsave.angularvelosyty = g1.angularVelocity;
            tsave.velosyty = g1.velocity;
            tsave.q1 = g.transform.rotation;
            tsave.q2 = g2.transform.rotation;
            tsave.pos = g.transform.position;
            tsave.vive = Camera.main.fieldOfView;
            timesaveing();
            gsave.hp = hp;
            gsave.oxygen = oxygen;
            gsave.tp = isthirdperson;
            save.idsave = ifd.text;
            File.WriteAllText("unsavet/capter" + SceneManager.GetActiveScene().buildIndex + "/" + ifd.text, JsonUtility.ToJson(save));
            gsave.idsave = ifd.text;
            gsave.sceneid = SceneManager.GetActiveScene().buildIndex;
            File.WriteAllText("unsavet/capterg/" + ifd.text, JsonUtility.ToJson(gsave));
            string s = "";
            s = ifd.text;
            File.WriteAllText("unsavet/s", s);
            WorldSave.SetVector4("var");
            WorldSave.SetVector3("var1");
        }
    }
    public void timesaveing()
    {



        if (!tutorial && !Input.GetKey(KeyCode.G) && Random.Range(0,3) ==2)
        {


            Directory.CreateDirectory("unsave/capter-" + SceneManager.GetActiveScene().buildIndex);
            tsave.angularvelosyty = g1.angularVelocity;
            tsave.velosyty = g1.velocity;
            tsave.q1 = g.transform.rotation;
            tsave.q2 = g2.transform.rotation;
            tsave.pos = g.transform.position;
            tsave.pos2 = g2.transform.position;
            tsave.vive = Camera.main.fieldOfView;

            save.idsave = ifd.text;
            DirectoryInfo di = new DirectoryInfo("unsave/capter-" + SceneManager.GetActiveScene().buildIndex);
            File.WriteAllText("unsave/capter-" + SceneManager.GetActiveScene().buildIndex + "/" + ifd.text + "-" + di.GetFiles().Length, JsonUtility.ToJson(tsave));



        }

    }
    
    public void deleteing()
    {

        if (!tutorial)
        {
            File.Delete("unsave/capter" + SceneManager.GetActiveScene().buildIndex + "/" + ifd.text);
            
        }
        else
        {
            File.Delete("unsavet/capter" + SceneManager.GetActiveScene().buildIndex + "/" + ifd.text);
            WorldSave.RemoveVector3();
        }

    }
}


