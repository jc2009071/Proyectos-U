/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */

package UsandoParqueo;

import org.junit.After;
import org.junit.AfterClass;
import org.junit.Before;
import org.junit.BeforeClass;
import org.junit.Test;
import static org.junit.Assert.*;

/**
 *
 * @author Luis Carlos
 */
public class UsandoListaTest {

    public UsandoListaTest() {
    }

    @BeforeClass
    public static void setUpClass() throws Exception {
    }

    @AfterClass
    public static void tearDownClass() throws Exception {
    }

    @Before
    public void setUp() {
    }

    @After
    public void tearDown() {
    }

    /**
     * Test of pop method, of class UsandoLista.
     */
    @Test
    public void testPop() {
        System.out.println("pop");
        UsandoLista instance = new UsandoLista();
        String expResult = null;
        String result = (String) instance.pop();
        assertEquals(expResult, result);
    }

    /**
     * Test of push method, of class UsandoLista.
     */
    @Test
    public void testPush() {
        System.out.println("push");
        String push = "jns";
        UsandoLista instance = new UsandoLista();
        instance.push(push);
    }

    /**
     * Test of peek method, of class UsandoLista.
     */
    @Test
    public void testPeek() {
        System.out.println("peek");
        UsandoLista instance = new UsandoLista();
        String expResult = null;
        String result = (String) instance.peek();
        assertEquals(expResult, result);
    }

}